namespace AdventOfCode.Year2021
{

    /// <summary>
    /// Cave Point
    /// </summary>
    public class CavePoint
    {

        /// <summary>
        /// Coordenate X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Coordenate Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Basin Value
        /// </summary>
        public int BasinValue { get; set; }

        /// <summary>
        /// Indicates if the basin level has been processed
        /// </summary>
        public bool BasinProcessed { get; set; }

        /// <summary>
        /// Indicates if the point is a risk level
        /// </summary>
        public bool IsRiskLevel { get; set; }

        /// <summary>
        /// Class Builder
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="value">Value</param>
        public CavePoint(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.BasinValue = 0;
            this.BasinProcessed = false;
            this.IsRiskLevel = false;
        }

    }
}