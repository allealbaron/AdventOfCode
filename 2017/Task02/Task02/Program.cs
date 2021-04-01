using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task02
    {
        /// <summary>
        /// Input
        /// </summary>
        private readonly List<List<int>> input = new();

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new (fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                input.Add (line.Split('\t').Select(c => Convert.ToInt32(c.ToString())).ToList());
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
            return (from t in input select t.Max() - t.Min()).Sum();
        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            return (from t in input
                      from t1 in t.ToList<int>()
                      from t2 in t.ToList<int>()
                      where ((t1 % t2 == 0) && (t1 != t2))
                      select t1 / t2).Sum();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task02(string fileName)
        {
            LoadFile(fileName);

        }

        static void Main()
        {
            Task02 t = new ("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
