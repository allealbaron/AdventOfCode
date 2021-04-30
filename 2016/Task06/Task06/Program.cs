using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Task06
    {
        /// <summary>
        /// Part
        /// </summary>
        private enum Part
        {
            FirstPart,
            SecondPart

        }

        /// <summary>
        /// Input
        /// </summary>
        private readonly List<String> input = new();

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
                input.Add(line);
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Common part for both parts
        /// </summary>
        /// <param name="part">Part</param>
        /// <returns>Solution</returns>
        private string GetSolution(Part part)
        {

            StringBuilder result = new();

            var groupedCharacters =
                            from l in input
                            from c in l.ToCharArray().Select((v, i) => new { character = v, index = i })
                            group c by new { c.character, c.index } into order
                            select new
                            {
                                order.Key.character,
                                order.Key.index,
                                count = order.Count()
                            };

            foreach (int i in groupedCharacters.Select(j => j.index).Distinct())
            {

                int countFilter = 0;

                if (part == Part.FirstPart)
                {
                    countFilter = (from g in groupedCharacters where g.index == i select g.count).Max();
                }
                else
                {
                    countFilter = (from g in groupedCharacters where g.index == i select g.count).Min();
                }

                result.Append((from g in groupedCharacters where g.index == i && g.count == countFilter select g.character).FirstOrDefault());

            }

            return result.ToString();

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public string FirstPart()
        {

            return this.GetSolution(Part.FirstPart);

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public string SecondPart()
        {

            return this.GetSolution(Part.SecondPart);

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task06(string fileName)
        {

            LoadFilePart(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {

            Task06 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}

