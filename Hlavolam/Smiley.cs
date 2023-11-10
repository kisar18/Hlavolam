namespace Hlavolam
{
    public class Smiley
    {
        /// <summary>
        /// Allowed half smiley types
        /// </summary>
        public enum SmileyType
        {
            Eyes,
            Mouth
        }

        /// <summary>
        /// Allowed background colors of half smiley
        /// </summary>
        public enum SmileyColor
        {
            Blue,
            Green,
            Yellow,
            Red
        }

        /// <summary>
        /// Represents background color of smiley
        /// </summary>
        public SmileyColor Color { get; set; }

        /// <summary>
        /// Represents type of half smiley
        /// </summary>
        public SmileyType Type { get; set; }

        /// <summary>
        /// Constructor of Smiley class
        /// </summary>
        /// <param name="color">Color of half smiley</param>
        /// <param name="type">Type of half smiley</param>
        public Smiley(SmileyColor color, SmileyType type)
        {
            this.Color = color;
            this.Type = type;
        }
    }
}