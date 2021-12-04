namespace AdventOfCode.Year2021
{
    /// <summary>
    /// Bingo Number
    /// </summary>
    public class BingoNumber
    {
        /// <summary>
        /// Value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Checked
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// Class Builder
        /// </summary>
        /// <param name="value">Value</param>
        public BingoNumber(int value)
        {
            this.Value = value;
            this.Checked = false;
        }
    }
}