using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task01
    {

        /// <summary>
        /// Expenses
        /// </summary>
        private readonly List<int> measurements = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {
            return (from i in measurements.Select((r, i) => new { Row = r, Index = i })
                    join j in measurements.Select((r, i) => new { Row = r, Index = i })
                    on
                        i.Index equals j.Index -1
                    where
                        i.Row<j.Row
                    select i.Row).Count();

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return (from e1 in measurements.Select((r, i) => new { Row = r, Index = i }).ToList()
                    from e2 in measurements.Select((r, i) => new { Row = r, Index = i }).ToList()
                    where
                           e1.Index == e2.Index - 3 &&
                           e1.Row < e2.Row
                    select e1.Row).Count();
            
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            measurements.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                measurements.Add(int.Parse(line));
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
