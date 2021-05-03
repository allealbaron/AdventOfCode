using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task07
    {

        /// <summary>
        /// Input
        /// </summary>
        private readonly List<IP> input = new();

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFilePart(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;
           
            while ((line = sr.ReadLine()) != null)
            {
                input.Add(new IP(line));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            return input.Where(p => p.IsValidForABBA()).Count();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            return input.Where(p => p.IsValidForABA()).Count();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task07(string fileName)
        {

            LoadFilePart(fileName);

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

