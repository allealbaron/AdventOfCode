using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class TreeProgram
    {
        /// <summary>
        /// Program name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Program weight
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Children
        /// </summary>
        public List<TreeProgram> Children = new();

    }
}
