using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2022
{
    public class Task04
    {

        /// <summary>
        /// Range of tasks an elf has to do
        /// </summary>
        private class Range
        {
            public int Start { get; set; }
            public int End { get; set; }
        }

        /// <summary>
        /// pairs
        /// </summary>
        private readonly List<Tuple<Range, Range>> _pairs = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            return _pairs.Count(t=> 
                                (t.Item1.Start<= t.Item2.Start
                                &&
                                t.Item1.End >= t.Item2.End)
                                ||
                                (t.Item2.Start <= t.Item1.Start
                                 &&
                                 t.Item2.End >= t.Item1.End)
            );

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return _pairs.Count(t =>
                (
                    (t.Item1.Start <= t.Item2.Start && t.Item1.End >= t.Item2.Start)
                    ||
                    (t.Item2.Start <= t.Item1.Start && t.Item2.End >= t.Item1.Start)
                    )
            );


        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            _pairs.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            string line;
            

            while ((line = sr.ReadLine()) != null)
            {

                var item1 = new Range();
                var item2 = new Range();

                bool secondItem = false;

                foreach (var part in line.Split(','))
                {

                    var subParts = part.Split('-');

                    var newRange = new Range() { Start = int.Parse(subParts[0]), End = int.Parse(subParts[1]) };

                    if (!secondItem)
                    {
                        item1 = newRange;
                        secondItem = true;
                    }
                    else
                    {
                        item2 = newRange;
                    }

                }

                _pairs.Add(new Tuple<Range, Range>(item1, item2));

            }
            

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task04(string fileName)
        {

            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task04 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
