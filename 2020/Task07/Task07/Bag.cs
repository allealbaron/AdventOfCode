using System.Collections.Generic;
using System.Linq;

namespace Task07
{
    /// <summary>
    /// Represents Group Response
    /// </summary>
    public class Bag
    {
        /// <summary>
        /// Quentity
        /// </summary>
        public int Quantity;

        /// <summary>
        /// Bag's name
        /// </summary>
        public string Name;

        /// <summary>
        /// Bags contained
        /// </summary>
        public Dictionary<string, Bag> BagsContained = new Dictionary<string,Bag>();

    }

   
}
