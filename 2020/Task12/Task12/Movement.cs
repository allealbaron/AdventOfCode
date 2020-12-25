using System;
using System.Collections.Generic;
using System.Text;

namespace Task12
{
    /// <summary>
    /// Ship movement
    /// </summary>
    class Movement
    {
        /// <summary>
        /// Move type
        /// </summary>
        public enum MoveEnum
        {
            N,
            S,
            E,
            W,
            L,
            R,
            F
        }

        /// <summary>
        /// Movement
        /// </summary>
        public MoveEnum Move;

        /// <summary>
        /// How many times the ship moves
        /// </summary>
        public int Quantity;

    }
}
