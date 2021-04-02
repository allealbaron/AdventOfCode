using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task05
    {
        /// <summary>
        /// Input
        /// </summary>
        private readonly List<int> input = new();

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                input.Add(Int32.Parse(line));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task05(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {
            int steps = 0;

            int cursor = 0;

            while (cursor < input.Count())
            {
                input[cursor]++;
                cursor += input[cursor]-1;
                steps++;
            }

            return steps;

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            int steps = 0;

            int cursor = 0;

            while (cursor < input.Count())
            {
                int newOffset = 1;
                if (input[cursor] >= 3)
                {
                    newOffset = -1;
                }
                
                input[cursor] += newOffset;
                cursor += input[cursor] - newOffset;
                steps++;

            }

            return steps;

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task05 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            t = new("input.txt");

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}

