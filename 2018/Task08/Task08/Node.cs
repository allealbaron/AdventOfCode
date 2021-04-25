using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Node
    {
        /// <summary>
        /// Sequence for ids
        /// </summary>
        static public int Sequence = 0;

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; }
           
        /// <summary>
        /// List of Child Nodes
        /// </summary>
        public List<Node> ChildNodes { get; set; }

        /// <summary>
        /// List of medatada
        /// </summary>
        public List<int> Metadata { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public Node()
        {
            this.Id = Sequence;
            this.ChildNodes = new();
            this.Metadata = new();

            Sequence++;

        }

    }
}
