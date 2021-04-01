using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Task01
    {

        /// <summary>
        /// Input
        /// </summary>
        private List<int> input;

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            input = File.ReadAllText(fileName).ToCharArray().Select(c=> Convert.ToInt32(c.ToString())).ToList();
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
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            var query = input.Select((x, i) => new { value = x, index = i }).OrderBy(t => t.index).ToList();

            return (from t1 in query
                      join t2 in query on t1.index equals ((t2.index + 1) % query.Count)
                      where t1.value == t2.value
                      select t1.value).Sum();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {
            var query = input.Select((x, i) => new { value = x, index = i }).OrderBy(t => t.index).ToList();

            return (from t1 in query
                        join t2 in query on t1.index equals ((t2.index + (query.Count/2)) % query.Count)
                        where t1.value == t2.value
                        select t1.value).Sum();

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        public static void Main()
        {
            Task01 t = new Task01("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
