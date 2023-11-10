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
        List<List<Square>> matrix = new List<List<Square>>();

        /// <summary>
        /// Represents number of rows of the matrix
        /// </summary>
        public int rows { get; set; }

        /// <summary>
        /// Represents number of columns of the matrix
        /// </summary>
        public int columns { get; set; }

        /// <summary>
        /// Constructor of Matrix class
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">Number of columns</param>
        public Matrix(int rows, int columns) 
        {
            this.columns = columns;
            this.rows = rows;

            for (int i = 0; i < rows; i++)
            {
                this.matrix.Add(new List<Square>());
            }
        }

        /// <summary>
        /// Method that fills the matrix with given squares data
        /// </summary>
        /// <param name="squares">Squares with smileys</param>
        public void FillMatrix(List<Square> squares)
        {
            for (int i = 0; i < this.rows; i++)
            {
                for(int j = 0; j < this.columns; j++)
                {
                    this.matrix[i].Add(squares[i * this.rows + j]);
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
            get { return matrix[row][column]; }
            set { matrix[row][column] = value; }
        }

        /// <summary>
        /// Method that checks if a puzzle is solved
        /// </summary>
        /// <returns>True if the puzzle is solved, otherwise false</returns>
        public bool IsPuzzleSolved()
        {
            for (int i = 0; i < this.matrix.Count; i++)
            {
                for (int j = 0; j < this.matrix[i].Count; j++)
                {
                    if (i == 0)
                    {
                        if ((j == 0 || j == 1) && !this.matrix[i][j].IsMyRightMatchingWith(this.matrix[i][j + 1]))
                        {
                            Console.WriteLine("\nPuzzle is not solved\n");
                            return false;
                        }
                    }
                    else if (i == 1)
                    {
                        if ((j == 0 || j == 1) && (!this.matrix[i][j].IsMyRightMatchingWith(this.matrix[i][j + 1]) || !this.matrix[i][j].IsMyTopMatchingWith(this.matrix[i - 1][j])))
                        {
                            Console.WriteLine("\nPuzzle is not solved\n");
                            return false;
                        }
                        else if (j == 2 && !this.matrix[i][j].IsMyTopMatchingWith(this.matrix[i - 1][j]))
                        {
                            Console.WriteLine("\nPuzzle is not solved\n");
                            return false;
                        }
                    }
                    else
                    {
                        if ((j == 0 || j == 1) && (!this.matrix[i][j].IsMyRightMatchingWith(this.matrix[i][j + 1]) || !this.matrix[i][j].IsMyTopMatchingWith(this.matrix[i - 1][j])))
                        {
                            Console.WriteLine("\nPuzzle is not solved\n");
                            return false;
                        }
                        else if (j == 2 && !this.matrix[i][j].IsMyTopMatchingWith(this.matrix[i - 1][j]))
                        {
                            Console.WriteLine("\nPuzzle is not solved\n");
                            return false;
                        }
                    }
                }
            }

            Console.WriteLine("\nPuzzle is solved\n");
            return true;
        }

        /// <summary>
        /// Method for printing a content of matrix
        /// </summary>
        public void PrintMatrix()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Square at row: " + i + " , column: " + j);
                    Console.WriteLine("TOP: " + this.matrix[i][j].TopSmiley.Color + " " + this.matrix[i][j].TopSmiley.Type);
                    Console.WriteLine("BOTTOM: " + this.matrix[i][j].BottomSmiley.Color + " " + this.matrix[i][j].BottomSmiley.Type);
                    Console.WriteLine("LEFT: " + this.matrix[i][j].LeftSmiley.Color + " " + this.matrix[i][j].LeftSmiley.Type);
                    Console.WriteLine("RIGHT: " + this.matrix[i][j].RightSmiley.Color + " " + this.matrix[i][j].RightSmiley.Type);
                }
            }
        }
    }
}
