namespace AdventOfCode.Year2021
{
    /// <summary>
    /// Vent Coordenate
    /// </summary>
    public class VentCoordenate
    {
        /// <summary>
        /// X Coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y Coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public int Value  {get; set;}

        /// <summary>
        /// Class Builder
        /// </summary>
        /// <param name="X">X value</param>
        /// <param name="Y">Y value</param>
        /// <param name="value">value</param>
        public VentCoordenate(int X, int Y,int value)
        {
            this.X = X;
            this.Y = Y;
            this.Value = value;
        }

    }
}