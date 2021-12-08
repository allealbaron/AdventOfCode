using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task08
    {

        /// <summary>
        /// Segment Inputs
        /// </summary>
        private readonly List<SegmentInput> segmentInputs = new();

       
        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {
            return (from s in segmentInputs
                     from n in s.NumbersDisplayed
                     where (n.Length == 2 || n.Length == 4 || n.Length == 3 || n.Length == 7)
                     select n).Count();

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return (from s in segmentInputs select s.GetValue()).Sum();

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            segmentInputs.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                segmentInputs.Add(new (line));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task08(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task08 t = new("Testinput.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
