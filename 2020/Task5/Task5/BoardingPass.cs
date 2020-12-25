using System;
using System.Collections.Generic;
using System.Text;

namespace Task5
{
    /// <summary>
    /// Represents a boarding pass
    /// </summary>
    public class BoardingPass
    {
        public int Row;
        public int Column;

        /// <summary>
        /// Seat id
        /// </summary>
        public int SeatId => (Row * 8) + Column;

    }
}
