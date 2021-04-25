using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task01
    {

        /// <summary>
        /// List of entries
        /// </summary>
        private readonly List<int> entries = new();

        /// <summary>
        /// Calculates fuel necessary for the first part
        /// </summary>
        /// <param name="mass">Mass</param>
        /// <returns>Fuel necessary</returns>
        public static int CalculateFuelFirstPart(int mass)
        {
            return int.Parse(Math.Floor((decimal)(mass / 3)).ToString()) -2;
        }

        /// <summary>
        /// Calculates fuel necessary for the second part
        /// </summary>
        /// <param name="mass">Mass</param>
        /// <returns>Fuel necessary</returns>
        public static int CalculateFuelSecondPart(int mass)
        {

            int result = 0;

            while (mass > 2)
            {
                
                int nextValue = CalculateFuelFirstPart(mass);

                if (nextValue > 0)
                {
                    result += nextValue;
                }
                
                mass = nextValue;

            }

            return result;

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>result</returns>
        public int FirstPart()
        {

            return (from t in entries select CalculateFuelFirstPart(t)).Sum();

        }

        /// <summary>
        /// Second part
        /// </summary>
        /// <returns>result</returns>
        public int SecondPart()
        {

            return (from t in entries select CalculateFuelSecondPart(t)).Sum();

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            entries.Clear();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new (fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                entries.Add(int.Parse(line));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task01(string fileName)
        {

            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {

            Task01 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
