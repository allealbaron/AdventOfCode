using System.Drawing;

namespace AdventOfCode
{
    /// <summary>
    /// Lightbulb order
    /// </summary>
    public class LightBulbOrder
    {
        /// <summary>
        /// Order kind
        /// </summary>
        public enum LightBulbOrderEnum
        { 
            TurnOn,
            TurnOff,
            Toggle
        }

        /// <summary>
        /// Order
        /// </summary>
        public LightBulbOrderEnum Order { get; set; }

        /// <summary>
        /// Init Point
        /// </summary>
        public Point InitPoint { get; set; }

        /// <summary>
        /// End Point
        /// </summary>
        public Point EndPoint { get; set; }

    }
}
