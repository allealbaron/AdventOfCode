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
        /// Expenses
        /// </summary>
        private readonly List<int> expenses = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {
            return (from i in expenses
                    join j in expenses
                    on
                        i equals 2020 - j
                    where
                        i>j
                    select i*j).First();

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return (from e1 in expenses
                    from e2 in expenses
                    from e3 in expenses
                    where (2020 == (e1+ e2 + e3) && e1>e2 && e2>e3)
                    select e1 * e2 * e3).First();

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            expenses.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                expenses.Add(int.Parse(line));
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
