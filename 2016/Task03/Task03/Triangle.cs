using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    /// <summary>
    /// Triangle
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// Sides
        /// </summary>
        public List<int> Sides = new(3);

        /// <summary>
        /// Validates the triangle
        /// </summary>
        /// <returns>True if the sum of two sides
        /// always is greater than the other</returns>
        public bool Validate()
        {
            return (Sides[0] + Sides[1] > Sides[2]) &&
                   (Sides[1] + Sides[2] > Sides[0]) &&
                   (Sides[0] + Sides[2] > Sides[1]);

        }

    }
}
