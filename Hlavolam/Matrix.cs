using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hlavolam
{
    public class Matrix
    {
        /// <summary>
        /// Represents matrix of squares of the puzzle
        /// </summary>
        public List<List<Square>> MatrixOfSquares = new List<List<Square>>();

        /// <summary>
        /// Represents number of rows of the matrix
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// Represents number of columns of the matrix
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// Constructor of Matrix class
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">Number of columns</param>
        public Matrix(int rows, int columns) 
        {
            this.Columns = columns;
            this.Rows = rows;

            for (int i = 0; i < rows; i++)
            {
                this.MatrixOfSquares.Add(new List<Square>());
            }
        }

        /// <summary>
        /// Method that fills the matrix with given squares data
        /// </summary>
        /// <param name="squares">Squares with smileys</param>
        public void FillMatrix(List<Square> squares)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for(int j = 0; j < this.Columns; j++)
                {
                    this.MatrixOfSquares[i].Add(squares[i * this.Rows + j]);
                }
            }
        }

        /// <summary>
        /// Indexer for accessing elements of the matrix
        /// </summary>
        /// <param name="row">Row of the access</param>
        /// <param name="column">Column of the access</param>
        /// <returns>Square on the required row and column</returns>
        public Square this[int row, int column]
        {
            get { return MatrixOfSquares[row][column]; }
            set { MatrixOfSquares[row][column] = value; }
        }

        /// <summary>
        /// Method that checks if a puzzle is solved
        /// </summary>
        /// <returns>True if the puzzle is solved, otherwise false</returns>
        public bool IsPuzzleSolved()
        {
            int solvedSquares = 0;
            for (int i = 0; i < this.MatrixOfSquares.Count; i++)
            {
                for (int j = 0; j < this.MatrixOfSquares[i].Count; j++)
                {
                    if (i == 0)
                    {
                        // Checking top-left square
                        if(j == 0 && this.MatrixOfSquares[i][j].IsMyRightMatchingWith(this.MatrixOfSquares[i][j + 1]) && 
                            this.MatrixOfSquares[i][j].IsMyBottomMatchingWith(this.MatrixOfSquares[i + 1][j]))
                        {
                            solvedSquares++;
                        }
                        // Checking top-middle square
                        else if (j == 1 && this.MatrixOfSquares[i][j].IsMyRightMatchingWith(this.MatrixOfSquares[i][j + 1]) && 
                            this.MatrixOfSquares[i][j].IsMyBottomMatchingWith(this.MatrixOfSquares[i + 1][j]) &&
                            this.MatrixOfSquares[i][j].IsMyLeftMatchingWith(this.MatrixOfSquares[i][j - 1]))
                        {
                            solvedSquares++;
                        }
                        // Checking top-right square
                        else if (j == 2 && this.MatrixOfSquares[i][j].IsMyLeftMatchingWith(this.MatrixOfSquares[i][j - 1]) &&
                            this.MatrixOfSquares[i][j].IsMyBottomMatchingWith(this.MatrixOfSquares[i + 1][j]))
                        {
                            solvedSquares++;
                        }
                    }
                    else if (i == 1)
                    {
                        // Checking middle-left square
                        if (j == 0  && this.MatrixOfSquares[i][j].IsMyRightMatchingWith(this.MatrixOfSquares[i][j + 1]) && 
                            this.MatrixOfSquares[i][j].IsMyTopMatchingWith(this.MatrixOfSquares[i - 1][j]) &&
                            this.MatrixOfSquares[i][j].IsMyBottomMatchingWith(this.MatrixOfSquares[i + 1][j]))
                        {
                            solvedSquares++;
                        }
                        // Checking center square
                        else if (j == 1 && this.MatrixOfSquares[i][j].IsMyRightMatchingWith(this.MatrixOfSquares[i][j + 1]) &&
                            this.MatrixOfSquares[i][j].IsMyTopMatchingWith(this.MatrixOfSquares[i - 1][j]) &&
                            this.MatrixOfSquares[i][j].IsMyBottomMatchingWith(this.MatrixOfSquares[i + 1][j]) &&
                            this.MatrixOfSquares[i][j].IsMyLeftMatchingWith(this.MatrixOfSquares[i][j - 1]))
                        {
                            solvedSquares++;
                        }
                        // Checking middle-right square
                        else if (j == 2 && this.MatrixOfSquares[i][j].IsMyLeftMatchingWith(this.MatrixOfSquares[i][j - 1]) &&
                            this.MatrixOfSquares[i][j].IsMyTopMatchingWith(this.MatrixOfSquares[i - 1][j]) &&
                            this.MatrixOfSquares[i][j].IsMyBottomMatchingWith(this.MatrixOfSquares[i + 1][j]))
                        {
                            solvedSquares++;
                        }
                    }
                    else
                    {
                        // Checking bottom-left square
                        if (j == 0 && this.MatrixOfSquares[i][j].IsMyRightMatchingWith(this.MatrixOfSquares[i][j + 1]) &&
                            this.MatrixOfSquares[i][j].IsMyTopMatchingWith(this.MatrixOfSquares[i - 1][j]))
                        {
                            solvedSquares++;
                        }
                        // Checking bottom-middle square
                        else if (j == 1 && this.MatrixOfSquares[i][j].IsMyRightMatchingWith(this.MatrixOfSquares[i][j + 1]) &&
                            this.MatrixOfSquares[i][j].IsMyTopMatchingWith(this.MatrixOfSquares[i - 1][j]) &&
                            this.MatrixOfSquares[i][j].IsMyLeftMatchingWith(this.MatrixOfSquares[i][j - 1]))
                        {
                            solvedSquares++;
                        }
                        // Checking bottom-right square
                        else if (j == 2 && this.MatrixOfSquares[i][j].IsMyLeftMatchingWith(this.MatrixOfSquares[i][j - 1]) &&
                            this.MatrixOfSquares[i][j].IsMyTopMatchingWith(this.MatrixOfSquares[i - 1][j]))
                        {
                            solvedSquares++;
                        }
                    }
                }
            }

            if(solvedSquares == 9)
            {
                Console.WriteLine("\nPuzzle is solved\n");
            }
            else
            {
                Console.WriteLine("\nPuzzle is not solved");
                Console.WriteLine("Solved only " + solvedSquares + " squares\n");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method for printing a content of matrix
        /// </summary>
        public void PrintMatrix()
        {
            string matrixRowTop = "";
            string matrixRowLeft = "";
            string matrixRowRight = "";
            string matrixRowBottom = "";

            Console.WriteLine("");
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    matrixRowTop += ("TOP: " + this.MatrixOfSquares[i][j].TopSmiley.Color + " " + this.MatrixOfSquares[i][j].TopSmiley.Type).PadRight(30);
                    matrixRowLeft += ("LEFT: " + this.MatrixOfSquares[i][j].LeftSmiley.Color + " " + this.MatrixOfSquares[i][j].LeftSmiley.Type).PadRight(30);
                    matrixRowRight += ("RIGHT: " + this.MatrixOfSquares[i][j].RightSmiley.Color + " " + this.MatrixOfSquares[i][j].RightSmiley.Type).PadRight(30);
                    matrixRowBottom += ("BOTTOM: " + this.MatrixOfSquares[i][j].BottomSmiley.Color + " " + this.MatrixOfSquares[i][j].BottomSmiley.Type).PadRight(30);

                }
                Console.WriteLine(matrixRowTop);
                Console.WriteLine(matrixRowLeft);
                Console.WriteLine(matrixRowRight);
                Console.WriteLine(matrixRowBottom);
                Console.WriteLine("");

                matrixRowTop = "";
                matrixRowLeft = "";
                matrixRowRight = "";
                matrixRowBottom = "";
            }
        }

        /// <summary>
        /// Method that tries to solve the puzzle from the top left corner
        /// </summary>
        public void TryToSolveMatrixFromTopLeftCorner()
        {
            int rowToSolve = 0;
            int columnToSolve = 0;
            int numberOfRotations = 4;
            bool wasSwap = false;

            // Iterating through other squares and checking the puzzle rules
            for (int k = 0; k < this.Rows; k++)
            {
                for (int l = 0; l < this.Columns; l++)
                {
                    // Skipping the first square because it is a starting point
                    if (k == 0 && l == 0)
                    {
                        columnToSolve += 1;
                        continue;
                    }

                    // Rotating square, if rules match break the rotations
                    for (int m = 0; m < numberOfRotations; m++)
                    {
                        // Rules for squares in the first row of matrix
                        if (rowToSolve == 0 && this.MatrixOfSquares[rowToSolve][columnToSolve - 1].IsMyRightMatchingWith(this.MatrixOfSquares[k][l]))
                        {
                            this.MatrixOfSquares[rowToSolve][columnToSolve].SwapWith(this.MatrixOfSquares[k][l]);
                            Console.WriteLine("Swapped row1: " + rowToSolve + " col1: " + columnToSolve + " row2: " + k + " col2: " + l);
                            columnToSolve += 1;
                            wasSwap = true;
                            break;
                        }
                        // Rules for squares in the second and third row of matrix
                        else if ((rowToSolve == 1 || rowToSolve == 2) && columnToSolve == 0 && this.MatrixOfSquares[rowToSolve - 1][columnToSolve].IsMyBottomMatchingWith(this.MatrixOfSquares[k][l]))
                        {
                            this.MatrixOfSquares[rowToSolve][columnToSolve].SwapWith(this.MatrixOfSquares[k][l]);
                            Console.WriteLine("Swapped row1: " + rowToSolve + " col1: " + columnToSolve + " row2: " + k + " col2: " + l);
                            columnToSolve += 1;
                            wasSwap = true;
                            break;
                        }
                        else if ((rowToSolve == 1 || rowToSolve == 2) && columnToSolve != 0 && this.MatrixOfSquares[rowToSolve][columnToSolve - 1].IsMyRightMatchingWith(this.MatrixOfSquares[k][l])
                            && this.MatrixOfSquares[rowToSolve - 1][columnToSolve].IsMyBottomMatchingWith(this.MatrixOfSquares[k][l]))
                        {
                            this.MatrixOfSquares[rowToSolve][columnToSolve].SwapWith(this.MatrixOfSquares[k][l]);
                            Console.WriteLine("Swapped row1: " + rowToSolve + " col1: " + columnToSolve + " row2: " + k + " col2: " + l);
                            columnToSolve += 1;
                            wasSwap = true;
                            break;
                        }

                        this.MatrixOfSquares[k][l].RotateSquareRight();
                    }

                    if (columnToSolve == 3)
                    {
                        rowToSolve += 1;
                        columnToSolve = 0;
                    }
                    
                    if(wasSwap)
                    {
                        k = rowToSolve;
                        l = columnToSolve - 1;
                        wasSwap = false;
                    }
                }
            }
        }

        /// <summary>
        /// Method that sorts the squares of the matrix by priority from 1 to 3
        /// </summary>
        public void SortMatrixSquaresByPriority()
        {
            List<int> CountsOfPriorities = new List<int>() { 0, 0 };

            for (int i = 0; i < this.Rows * this.Columns; i++)
            {
                CountsOfPriorities[this.MatrixOfSquares[i / this.Rows][i % this.Columns].Priority - 1]++;
            }

            int alreadySwapped = 0;
            // Iterationg through the squares and increasing corresponding priority count
            for (int i = 0; i < this.Rows * this.Columns; i++)
            {
                if (CountsOfPriorities[0] != 0)
                {
                    for (int j = alreadySwapped; j < this.Rows * this.Columns; j++)
                    {
                        if (this.MatrixOfSquares[j / this.Rows][j % this.Columns].Priority == 1)
                        {
                            this.MatrixOfSquares[j / this.Rows][j % this.Columns].SwapWith(this.MatrixOfSquares[alreadySwapped / 3][alreadySwapped % 3]);
                            alreadySwapped++;
                            CountsOfPriorities[0]--;
                            break;
                        }
                    }
                }
                else if (CountsOfPriorities[1] != 0)
                {
                    for (int j = alreadySwapped; j < this.Rows * this.Columns; j++)
                    {
                        if (this.MatrixOfSquares[j / this.Rows][j % this.Columns].Priority == 2)
                        {
                            this.MatrixOfSquares[j / this.Rows][j % this.Columns].SwapWith(this.MatrixOfSquares[alreadySwapped / 3][alreadySwapped % 3]);
                            alreadySwapped++;
                            CountsOfPriorities[1]--;
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = alreadySwapped; j < this.Rows * this.Columns; j++)
                    {
                        if (this.MatrixOfSquares[j / this.Rows][j % this.Columns].Priority == 3)
                        {
                            this.MatrixOfSquares[j / this.Rows][j % this.Columns].SwapWith(this.MatrixOfSquares[alreadySwapped / 3][alreadySwapped % 3]);
                            alreadySwapped++;
                            CountsOfPriorities[2]--;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method that tries to solve the puzzle from the center square
        /// </summary>
        public void TryToSolveFromCenter()
        {
            int numberOfRotations = 4;
            int centerRow = 1;
            int centerCol = 1;
            List<int> CountsOfPriorities = new List<int>() { 0, 0 };
            // Top, Bottom, Left, Right
            List<bool> MatchedSides = new List<bool>() { false, false, false, false };
            // Top-Left, Top-Right, Bottom-Right, Bottom-Left
            List<bool> MatchedCorners = new List<bool>() { false, false, false, false };

            bool wasIResetedBefore = false;

            for (int i = 0; i < this.Rows * this.Columns; i++)
            {
                CountsOfPriorities[this.MatrixOfSquares[i / this.Rows][i % this.Columns].Priority - 1]++;
            }

            // Looping through the squares and adding the squares in order by priority
            for (int i = 0; i < this.Rows * this.Columns; i++)
            {
                for (int m = 0; m < numberOfRotations; m++)
                {
                    if (i / this.Rows == 1 && i % this.Columns == 1) 
                    { 
                        continue;
                    }

                    Square current = this.MatrixOfSquares[i / this.Rows][i % this.Columns];

                    // Checking squares if they can be added to any side of matrix
                    if (CountsOfPriorities[0] + CountsOfPriorities[1] != 1 && current.Priority == 1)
                    {
                        if (!MatchedSides[0] && this.MatrixOfSquares[centerRow][centerCol].IsMyTopMatchingWith(current))
                        {
                            current.SwapWith(this.MatrixOfSquares[centerRow - 1][centerCol]);
                            Console.WriteLine("Swapped row1: " + (i / this.Rows) + " col1: " + (i % this.Columns) + " row2: " + (centerRow - 1) + " col2: " + centerCol);
                            CountsOfPriorities[0]--;
                            MatchedSides[0] = true;
                            break;
                        }
                        else if (!MatchedSides[1] && this.MatrixOfSquares[centerRow][centerCol].IsMyBottomMatchingWith(current))
                        {
                            this.MatrixOfSquares[i / this.Rows][i % this.Columns].SwapWith(this.MatrixOfSquares[centerRow + 1][centerCol]);
                            Console.WriteLine("Swapped row1: " + (i / this.Rows) + " col1: " + (i % this.Columns) + " row2: " + (centerRow + 1) + " col2: " + centerCol);
                            CountsOfPriorities[0]--;
                            MatchedSides[1] = true;
                            break;
                        }
                        else if (!MatchedSides[2] && this.MatrixOfSquares[centerRow][centerCol].IsMyLeftMatchingWith(current))
                        {
                            current.SwapWith(this.MatrixOfSquares[centerRow][centerCol - 1]);
                            Console.WriteLine("Swapped row1: " + (i / this.Rows) + " col1: " + (i % this.Columns) + " row2: " + centerRow + " col2: " + (centerCol - 1));
                            CountsOfPriorities[0]--;
                            MatchedSides[2] = true;
                            break;
                        }
                        else if (!MatchedSides[3] && this.MatrixOfSquares[centerRow][centerCol].IsMyRightMatchingWith(current))
                        {
                            this.MatrixOfSquares[i / this.Rows][i % this.Columns].SwapWith(this.MatrixOfSquares[centerRow][centerCol + 1]);
                            Console.WriteLine("Swapped row1: " + (i / this.Rows) + " col1: " + (i % this.Columns) + " row2: " + centerRow + " col2: " + (centerCol + 1));
                            CountsOfPriorities[0]--;
                            MatchedSides[3] = true;
                            break;
                        }
                    }
                    // Checking squares if they can be added to any corner of matrix
                    else if (MatchedSides[0] && MatchedSides[1] && MatchedSides[2] && MatchedSides[3])
                    {
                        if (current.Priority == 2)
                        {
                            // Resetting "i" to be able to return to the potential corners in the beginning of the matrix
                            if(!wasIResetedBefore)
                            {
                                i = 0;
                                wasIResetedBefore = true;
                            }

                            if (!MatchedCorners[0] && this.MatrixOfSquares[centerRow - 1][centerCol].IsMyLeftMatchingWith(current) &&
                                this.MatrixOfSquares[centerRow][centerCol - 1].IsMyTopMatchingWith(current))
                            {
                                current.SwapWith(this.MatrixOfSquares[centerRow - 1][centerCol - 1]);
                                Console.WriteLine("Swapped row1: " + (i / this.Rows) + " col1: " + (i % this.Columns) + " row2: " + (centerRow - 1) + " col2: " + centerCol);
                                MatchedCorners[0] = true;
                                break;
                            }
                            else if (!MatchedCorners[1] && this.MatrixOfSquares[centerRow - 1][centerCol].IsMyRightMatchingWith(current) &&
                                this.MatrixOfSquares[centerRow][centerCol + 1].IsMyTopMatchingWith(current))
                            {
                                current.SwapWith(this.MatrixOfSquares[centerRow - 1][centerCol + 1]);
                                Console.WriteLine("Swapped row1: " + (i / this.Rows) + " col1: " + (i % this.Columns) + " row2: " + (centerRow + 1) + " col2: " + centerCol);
                                MatchedCorners[1] = true;
                                break;
                            }
                            else if (!MatchedCorners[2] && this.MatrixOfSquares[centerRow + 1][centerCol + 1].IsMyRightMatchingWith(current) &&
                                this.MatrixOfSquares[centerRow][centerCol + 1].IsMyBottomMatchingWith(current))
                            {
                                current.SwapWith(this.MatrixOfSquares[centerRow][centerCol - 1]);
                                Console.WriteLine("Swapped row1: " + (i / this.Rows) + " col1: " + (i % this.Columns) + " row2: " + centerRow + " col2: " + (centerCol - 1));
                                MatchedCorners[2] = true;
                                break;
                            }
                            else if (!MatchedCorners[3] && this.MatrixOfSquares[centerRow + 1][centerCol - 1].IsMyLeftMatchingWith(current) &&
                                this.MatrixOfSquares[centerRow][centerCol - 1].IsMyBottomMatchingWith(current))
                            {
                                current.SwapWith(this.MatrixOfSquares[centerRow][centerCol + 1]);
                                Console.WriteLine("Swapped row1: " + (i / this.Rows) + " col1: " + (i % this.Columns) + " row2: " + centerRow + " col2: " + (centerCol + 1));
                                MatchedCorners[3] = true;
                                break;
                            }
                        }
                    }
                    current.RotateSquareRight();
                }
            }
        }
    }
}
