namespace AdventOfCode.Year2021
{
    /// <summary>
    /// Represents a segment digit
    /// </summary>
    public  class SegmentDigit
    {
        /// <summary>
        /// Code Value
        /// </summary>
        public string CodeValue { get; set; }

        /// <summary>
        /// Number value
        /// </summary>
        public int DigitValue { get; set; }

        /// <summary>
        /// Creates a new Segment Digit
        /// </summary>
        /// <param name="codeValue">Code value</param>
        public SegmentDigit(string codeValue)
        {
            this.CodeValue = codeValue;
            this.DigitValue = -1;
        }
    }
}