using Hlavolam;

// Create squares of matrix and initialize them with values from task assignment

Smiley BlueEyes = new Smiley(Smiley.SmileyColor.Blue, Smiley.SmileyType.Eyes);
Smiley GreenEyes = new Smiley(Smiley.SmileyColor.Green, Smiley.SmileyType.Eyes);
Smiley YellowEyes = new Smiley(Smiley.SmileyColor.Yellow, Smiley.SmileyType.Eyes);
Smiley RedEyes = new Smiley(Smiley.SmileyColor.Red, Smiley.SmileyType.Eyes);

Smiley BlueMouth = new Smiley(Smiley.SmileyColor.Blue, Smiley.SmileyType.Mouth);
Smiley GreenMouth = new Smiley(Smiley.SmileyColor.Green, Smiley.SmileyType.Mouth);
Smiley YellowMouth = new Smiley(Smiley.SmileyColor.Yellow, Smiley.SmileyType.Mouth);
Smiley RedMouth = new Smiley(Smiley.SmileyColor.Red, Smiley.SmileyType.Mouth);

/* 
 * I made a statistic of how often the given semi-smileys appear in the assignment. 
 * Some parts (green eyes, red mouth, and yellow eyes) occur more frequently in the 
 * assignment than their opposites, so I think they are more likely to be in the corners 
 * of the matrix. Squares that contain at least 2 of the mentioned parts therefore 
 * received priority 2.
 */
Square square00 = new Square(RedMouth, RedEyes, GreenEyes, YellowMouth, 2);
Square square01 = new Square(BlueEyes, BlueMouth, GreenMouth, YellowEyes, 1);
Square square02 = new Square(RedEyes, BlueMouth, YellowMouth, YellowEyes, 1);
Square square10 = new Square(RedMouth, GreenEyes, RedMouth, BlueEyes, 2);
Square square11 = new Square(BlueEyes, RedMouth, YellowMouth, GreenEyes, 1);
Square square12 = new Square(BlueMouth, RedEyes, GreenEyes, YellowMouth, 1);
Square square20 = new Square(BlueMouth, YellowEyes, BlueEyes, GreenMouth, 1);
Square square21 = new Square(BlueEyes, BlueMouth, YellowEyes, RedMouth, 2);
Square square22 = new Square(YellowEyes, GreenMouth, GreenEyes, RedMouth, 2);
List<Square> squares = new List<Square>() { square00, square01, square02, square10, square11, square12, square20, square21, square22 };

// Add squares into matrices
Matrix inputMatrix = new Matrix(3, 3);
inputMatrix.FillMatrix(squares);

// List of output matrices, each with different top-left square
List<Matrix> matrices = new List<Matrix>();

for (int m = 0; m < inputMatrix.Rows * inputMatrix.Columns * 2; m++)
{
    // Matrices for solving from top-left corner
    if(m < inputMatrix.Rows * inputMatrix.Columns)
    {
        matrices.Add(new Matrix(3, 3));

        List<Square> copiedSquares = squares.Select(square =>
            new Square(
                new Smiley(square.TopSmiley.Color, square.TopSmiley.Type),
                new Smiley(square.BottomSmiley.Color, square.BottomSmiley.Type),
                new Smiley(square.LeftSmiley.Color, square.LeftSmiley.Type),
                new Smiley(square.RightSmiley.Color, square.RightSmiley.Type),
                square.Priority
            )
        ).ToList();

        matrices[m].FillMatrix(copiedSquares);
        matrices[m][0, 0].SwapWith(matrices[m][m / 3, m % 3]);
    }
    // Matrices for solving from center
    else
    {
        matrices.Add(new Matrix(3, 3));

        List<Square> copiedSquares = squares.Select(square =>
            new Square(
                new Smiley(square.TopSmiley.Color, square.TopSmiley.Type),
                new Smiley(square.BottomSmiley.Color, square.BottomSmiley.Type),
                new Smiley(square.LeftSmiley.Color, square.LeftSmiley.Type),
                new Smiley(square.RightSmiley.Color, square.RightSmiley.Type),
                square.Priority
            )
        ).ToList();

        matrices[m].FillMatrix(copiedSquares);
        matrices[m].SortMatrixSquaresByPriority();
        matrices[m][1, 1].SwapWith(matrices[m][(m / 3) % 3, m % 3]);
    }
}

int numberOfRotations = 4;
Console.WriteLine("Trying to solve the puzzle from top-left corner");

// Solving matrices from top-left corner
for (int i = 0; i < matrices.Count / 2; i++)
{
    // Trying all angles of a top-left square by rotating it
    for (int j = 0; j < numberOfRotations; j++)
    {
        if (j != 0)
        {
            matrices[i][0, 0].RotateSquareRight();
        }
        Console.WriteLine("Using square: " + i + " as a starting point");
        Console.WriteLine("Angle: " + (j + 1) + "\n");

        // Iterating through other squares and checking the puzzle rules
        matrices[i].TryToSolveMatrixFromTopLeftCorner();
        matrices[i].PrintMatrix();

        // Check if puzzle is solved
        if (matrices[i].IsPuzzleSolved())
        {
            break;
        }
    }
}

Console.WriteLine("Trying to solve the puzzle from center square");
// Solving matrices from center
for (int i = matrices.Count / 2; i < matrices.Count; i++)
{
    // Trying all angles of a top-left square by rotating it
    for (int j = 0; j < numberOfRotations; j++)
    {
        if (j != 0)
        {
            matrices[i][1, 1].RotateSquareRight();
        }
        Console.WriteLine("Using square: " + i + " as a starting point");
        Console.WriteLine("Angle: " + (j + 1) + "\n");

        // Iterating through other squares and checking the puzzle rules
        matrices[i].TryToSolveFromCenter();
        matrices[i].PrintMatrix();

        // Check if puzzle is solved
        if (matrices[i].IsPuzzleSolved())
        {
            break;
        }
    }
}

Console.ReadKey();