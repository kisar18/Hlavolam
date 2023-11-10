using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hlavolam
{
    public class Square
    {
        public enum SquareEyesPosition
        {
            TopLeft,
            TopRight,
            BottomRight,
            BottomLeft
        }

        /// <summary>
        /// Represents half of a smiley that is located on the top side of square
        /// </summary>
        public Smiley TopSmiley { get; set; }

        /// <summary>
        /// Represents half of a smiley that is located on the bottom side of square
        /// </summary>
        public Smiley BottomSmiley { get; set; }

        /// <summary>
        /// Represents half of a smiley that is located on the left side of square
        /// </summary>
        public Smiley LeftSmiley { get; set; }

        /// <summary>
        /// Represents half of a smiley that is located on the right side of square
        /// </summary>
        public Smiley RightSmiley { get; set; }

        /// <summary>
        /// Represents position of 2 neighbour eyes in a square
        /// </summary>
        public SquareEyesPosition PositionOfTwoEyes { get; set; }

        /// <summary>
        /// Constructor of Square class
        /// </summary>
        /// <param name="topSmiley">Upper half smiley of the square</param>
        /// <param name="bottomSmiley">Bottom half smiley of the square</param>
        /// <param name="leftSmiley">Left half smiley of the square</param>
        /// <param name="rightSmiley">Right half smiley of the square</param>
        public Square(Smiley topSmiley, Smiley bottomSmiley, Smiley leftSmiley, Smiley rightSmiley)
        {
            this.TopSmiley = topSmiley;
            this.BottomSmiley = bottomSmiley;
            this.LeftSmiley = leftSmiley;
            this.RightSmiley = rightSmiley;

            if(this.TopSmiley.Type == Smiley.SmileyType.Eyes)
            {
                if(this.LeftSmiley.Type == Smiley.SmileyType.Eyes)
                {
                    this.PositionOfTwoEyes = SquareEyesPosition.TopLeft;
                }
                else
                {
                    this.PositionOfTwoEyes = SquareEyesPosition.TopRight;

                }
            }
            else
            {
                if (this.LeftSmiley.Type == Smiley.SmileyType.Eyes)
                {
                    this.PositionOfTwoEyes = SquareEyesPosition.BottomLeft;
                }
                else
                {
                    this.PositionOfTwoEyes = SquareEyesPosition.BottomRight;

                }
            }
        }

        /// <summary>
        /// Method for rotating a square by 90 degrees clockwise
        /// </summary>
        public void RotateSquareRight()
        {
            Smiley tmp = this.RightSmiley;
            this.RightSmiley = this.TopSmiley;
            this.TopSmiley = this.LeftSmiley;
            this.LeftSmiley = this.BottomSmiley;
            this.BottomSmiley = tmp;
        }

        /// <summary>
        /// Method for swapping the current square with other one in the matrix
        /// </summary>
        /// <param name="square">Square that will be swapped with the current one</param>
        public void SwapWith(Square square)
        {
            Square tmp = new Square(square.TopSmiley, square.BottomSmiley, square.LeftSmiley, square.RightSmiley);

            square.TopSmiley = this.TopSmiley;
            square.BottomSmiley = this.BottomSmiley;
            square.LeftSmiley = this.LeftSmiley;
            square.RightSmiley = this.RightSmiley;

            this.TopSmiley = tmp.TopSmiley;
            this.BottomSmiley = tmp.BottomSmiley;
            this.LeftSmiley = tmp.LeftSmiley;
            this.RightSmiley = tmp.RightSmiley;
        }

        /// <summary>
        /// Method that checks if the top part of a current square is matching with the bottom part of the other square
        /// </summary>
        /// <param name="square">Square that is being checked with the current one for the puzzle rules</param>
        /// <returns>True if the squares match the rules, otherwise false</returns>
        public bool IsMyTopMatchingWith(Square square)
        {
            if(this.TopSmiley.Type != square.BottomSmiley.Type && this.TopSmiley.Color == square.BottomSmiley.Color)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method that checks if the bottom part of a current square is matching with the top part of the other square
        /// </summary>
        /// <param name="square">Square that is being checked with the current one for the puzzle rules</param>
        /// <returns>True if the squares match the rules, otherwise false</returns>
        public bool IsMyBottomMatchingWith(Square square)
        {
            if (this.BottomSmiley.Type != square.TopSmiley.Type && this.BottomSmiley.Color == square.TopSmiley.Color)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Method that checks if the left part of a current square is matching with the right part of the other square
        /// </summary>
        /// <param name="square">Square that is being checked with the current one for the puzzle rules</param>
        /// <returns>True if the squares match the rules, otherwise false</returns>
        public bool IsMyLeftMatchingWith(Square square)
        {
            if (this.LeftSmiley.Type != square.RightSmiley.Type && this.LeftSmiley.Color == square.RightSmiley.Color)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method that checks if the right part of a current square is matching with the left part of the other square
        /// </summary>
        /// <param name="square">Square that is being checked with the current one for the puzzle rules</param>
        /// <returns>True if the squares match the rules, otherwise false</returns>
        public bool IsMyRightMatchingWith(Square square)
        {
            if (this.RightSmiley.Type != square.LeftSmiley.Type && this.RightSmiley.Color == square.LeftSmiley.Color)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
