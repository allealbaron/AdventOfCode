namespace AdventOfCode.Year2021
{
    public class Octopus
    {
        /// <summary>
        /// X position
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y position
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Indicates if a octopus has flashed
        /// </summary>
        public bool Flashed { get; set; }

        /// <summary>
        /// Class builder
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="value">value</param>
        public Octopus(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.Flashed = false;
        }

        /// <summary>
        /// Deflash the octopus
        /// </summary>
        public void DeFlash()
        {
            this.Value = 0;
            this.Flashed = false;
        }

        /// <summary>
        /// Flash the octopus
        /// </summary>
        public void Flash()
        {
            this.Value = 0;
            this.Flashed = true;
        }

        /// <summary>
        /// Increments octopus' value
        /// </summary>
        public void Increment()
        {
            this.Value++;
        }
    }
}