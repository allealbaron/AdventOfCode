using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task03
    {

        /// <summary>
        /// Lines
        /// </summary>
        private readonly List<string> lines = new();

        /// <summary>
        /// Calculates how many trees does the user hits
        /// </summary>
        /// <param name="horizontalMoves">Horizontal moves</param>
        /// <param name="verticalMoves">Vertical moves</param>
        /// <returns>Number of trees the user hits</returns>
        public int MoveThroughForest(int horizontalMoves, int verticalMoves)
        {
            int result = 0;
            int j = 0;

            for (int i = 0; i < lines.Count; i+=verticalMoves)
            {
                if (lines[i][j % lines[i].Length] == '#')
                {
                    result++;
                }
                j += horizontalMoves;
            }

            return result;
        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>result</returns>
        public int FirstPart()
        {
            return MoveThroughForest(3,1);
        }

        /// <summary>
        /// Second part
        /// </summary>
        /// <returns>result</returns>
        public uint SecondPart()
        {
          
            List<(int, int)> parameters = new()
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };

            return (parameters.Select(tuple => MoveThroughForest(tuple.Item1, tuple.Item2))
                                    .Aggregate((uint)1, (acc, val) => (uint)acc * (uint)val));
         
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            lines.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new (fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }

            sr.Close();
            fs.Close();


        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task03(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task03 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
