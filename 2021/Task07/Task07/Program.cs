using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task07
    {

        /// <summary>
        /// Crab Submarines
        /// </summary>
        private readonly List<int> crabSubmarines = new();

        /// <summary>
        /// Precalculated Sums
        /// </summary>
        private readonly List<int> precalculatedSums = new();

        /// <summary>
        /// Calculates fuel expended moving <paramref name="positions"/>
        /// </summary>
        /// <param name="positions">Positions</param>
        /// <returns>Fuel</returns>
        public int CalculateFuel(int positions)
        {
            return (from c in crabSubmarines
                    select Math.Abs(c-positions)).Sum();
        }

        /// <summary>
        /// Precalculate Sums
        /// </summary>
        private void PreCalculateSums()
        {
            precalculatedSums.Add(0);

            for (int i = 1; i <= crabSubmarines.Max(); i++)
            {
                precalculatedSums.Add(precalculatedSums[i - 1] + i);
            }

        }

        /// <summary>
        /// Calculates fuel expended moving <paramref name="positions"/>
        /// </summary>
        /// <param name="positions">Positions</param>
        /// <returns>Fuel</returns>
        public int CalculateFuelCrabMethod(int positions)
        {
            return (from c in crabSubmarines
                    select precalculatedSums[Math.Abs(c-positions)]).Sum();
        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            return (from i in Enumerable.Range(0, crabSubmarines.Max())
                    select CalculateFuel(i)).Min();

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return (from i in Enumerable.Range(0, crabSubmarines.Max())
                    select CalculateFuelCrabMethod(i)).Min();

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            crabSubmarines.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                foreach (string s in line.Split(','))
                {
                    crabSubmarines.Add(Int32.Parse(s));
                }
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task07(string fileName)
        {
            LoadFile(fileName);

            PreCalculateSums();

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task07 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
