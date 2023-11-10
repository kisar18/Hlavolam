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

Square square00 = new Square(RedMouth, RedEyes, GreenEyes, YellowMouth);
Square square01 = new Square(BlueEyes, BlueMouth, GreenMouth, YellowEyes);
Square square02 = new Square(RedEyes, BlueMouth, YellowMouth, YellowEyes);
Square square10 = new Square(RedMouth, GreenEyes, RedMouth, BlueEyes);
Square square11 = new Square(BlueEyes, RedMouth, YellowMouth, GreenEyes);
Square square12 = new Square(BlueMouth, RedEyes, GreenEyes, YellowMouth);
Square square20 = new Square(BlueMouth, YellowEyes, BlueEyes, GreenMouth);
Square square21 = new Square(BlueEyes, BlueMouth, YellowEyes, RedMouth);
Square square22 = new Square(YellowEyes, GreenMouth, GreenEyes, RedMouth);
List<Square> squares = new List<Square>() { square00, square01, square02, square10, square11, square12, square20, square21, square22 };

// Add squares into matrices

Matrix inputMatrix = new Matrix(3, 3);
inputMatrix.FillMatrix(squares);

// List of output matrices, each with different top-left square
List<Matrix> matrices = new List<Matrix>();

for (int m = 0; m < inputMatrix.rows * inputMatrix.columns; m++)
{
    matrices.Add(new Matrix(3, 3));

    List<Square> copiedSquares = squares.Select(square =>
        new Square(
            new Smiley(square.TopSmiley.Color, square.TopSmiley.Type),
            new Smiley(square.BottomSmiley.Color, square.BottomSmiley.Type),
            new Smiley(square.LeftSmiley.Color, square.LeftSmiley.Type),
            new Smiley(square.RightSmiley.Color, square.RightSmiley.Type)
        )
    ).ToList();

    matrices[m].FillMatrix(copiedSquares);
    matrices[m][0, 0].SwapWith(matrices[m][m / 3, m % 3]);
}

int numberOfRotations = 3;

// Solving each matrix in matrices
for (int i = 0; i < matrices.Count; i++)
{
    // Trying all angles of a top-left square by rotating it
    for (int j = 0; j < numberOfRotations + 1; j++)
    {
        if (j != 0)
        {
            matrices[i][0, 0].RotateSquareRight();
        }
        Console.WriteLine("Using square: " + i + " as a starting point");
        Console.WriteLine("Angle: " + (j + 1) + "\n");

        // Iterating through other squares and checking the puzzle rules
        matrices[i].TryToSolveMatrix();
        matrices[i].PrintMatrix();

        // Check if puzzle is solved
        if (matrices[i].IsPuzzleSolved())
        {
            break;
        }
    }
}