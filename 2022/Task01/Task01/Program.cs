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
        /// Elfs
        /// </summary>
        private readonly Dictionary<int, int> elfs = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            return elfs.Max(t => t.Value);

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return elfs.OrderByDescending(t => t.Value).Take(3).Sum(t=> t.Value);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            elfs.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;
            int elfNumber = 0;
            int calories = 0;

            while ((line = sr.ReadLine()) != null)
            {

                if (!string.IsNullOrEmpty(line))
                {
                    calories += Int32.Parse(line);
                }
                else
                {
                    elfs.Add(elfNumber, calories);
                    elfNumber++;
                    calories = 0;
                }

            }

            elfs.Add(elfNumber, calories);

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
