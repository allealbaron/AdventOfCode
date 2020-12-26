using System;
using System.Collections.Generic;
using System.Linq;

namespace Task13
{
    /// <summary>
    /// Input in this task
    /// </summary>
    class Input
    {
        /// <summary>
        /// Input id
        /// </summary>
        public String Id = String.Empty;
        
        /// <summary>
        /// Earliest Time Stamp
        /// </summary>
        public int EarliestTimeStamp =0;

        /// <summary>
        /// Raw scheduled
        /// </summary>
        public List<String> Schedule = new List<String>();

        /// <summary>
        /// Dictionary which contains bus id's and their
        /// offset with the first depature
        /// </summary>
        public Dictionary<int, int> Modules = new Dictionary<int, int>();

        /// <summary>
        /// Fill Modules Dictionary
        /// </summary>
        public void FillModules()
        {

            int counter = 0;

            for (int i = 0; i < Schedule.Count; i++)
            {
                if (!Schedule[i].Equals("x"))
                {
                    int number = int.Parse(Schedule[i]);
                    Modules.Add(number, (number-counter)%number);
                }
                    counter++;
            }

        }

        /// <summary>
        /// Calculates minimum waiting time
        /// </summary>
        /// <returns>Minimum waiting time</returns>
        public int CalculateMinimumWaitingTime()
        {
            return (from m in Modules
                    from n in Enumerable.Range(0, 100000)
                    where (m.Key * n >= EarliestTimeStamp)
                    orderby ((m.Key * n) - EarliestTimeStamp)
                     select ((m.Key * n) - EarliestTimeStamp)*m.Key).First();
        }

        /// <summary>
        /// Calculates Chinese RemainderTheorem (For Part 2)
        /// </summary>
        /// <returns>Chinese Remainder</returns>
        public Int64 CalculateChineseRemainderTheorem()
        {

            Int64 leastCommonMultiple = 1;

            foreach (int number in Modules.Keys)
            {
                leastCommonMultiple *= number;
            }

            Int64 acc = 0;

            foreach (KeyValuePair<int, int> kvp in Modules)
            {
                Int64 division = leastCommonMultiple / kvp.Key;
                acc += kvp.Value * ModularMultiplicativeInverse(division, kvp.Key) * division;
            }

            return (acc % leastCommonMultiple);

        }

        /// <summary>
        /// Modular Multiplicative Reverse
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="mod">Module</param>
        /// <returns>Result</returns>
        private static Int64 ModularMultiplicativeInverse(Int64 value, Int64 mod)
        {
            Int64 module = value % mod;

            for (int i = 1; i < mod; i++)
            {
                if ((module * i) % mod == 1)
                {
                    return i;
                }
            }

            return 1;
        }

    }
}
