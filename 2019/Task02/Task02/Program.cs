using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Task02
    {

        /// <summary>
        /// List of entiries
        /// </summary>
        private readonly List<int> entries = new();

        /// <summary>
        /// Computes First Part
        /// </summary>
        /// <returns>Value stored at position 0</returns>
        public int ComputeFirstPart()
        {

            int i = 0;

            while (entries[i] != 99)
            {
                switch (entries[i])
                {
                    case 1:
                        entries[entries[i + 3]] = (entries[entries[i + +1]] + entries[entries[i + 2]]);
                        i += 4;
                        break;
                    case 2:
                        entries[entries[i + 3]] = (entries[entries[i + +1]] * entries[entries[i + 2]]);
                        i += 4;
                        break;
                }
            }

            return entries[0];

        }

        /// <summary>
        /// Computes Second Part
        /// </summary>
        /// <returns>Result</returns>
        public int ComputeSecondPart()
        {
            const int GOAL = 19690720;

            int result = 0;
            int noun = 0;
            int verb = 0;

            while (result != GOAL && verb<100)
            {
                LoadFile("Input.txt");

                entries[1] = noun;
                entries[2] = verb;

                result = ComputeFirstPart();

                if (result != GOAL)
                {
                    if (noun < 99)
                    {
                        noun++;
                    }
                    else
                    {
                        noun = 0;
                        verb++;
                    }
                }
            }

            return (noun * 100 + verb);

        }
       
        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            return ComputeFirstPart();

        }

        /// <summary>
        /// Second part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            return ComputeSecondPart();

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            entries.Clear();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new (fs, Encoding.UTF8, true, BufferSize);
            String line;

            line = sr.ReadLine();

            foreach( string s in line.Split(","))
            { 
                entries.Add(int.Parse(s));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task02(string fileName)
        {

            LoadFile(fileName);

            if (fileName.ToLower().Equals("input.txt"))
            {
                entries[1] = 12;
                entries[2] = 2;
            }

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {

            Task02 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
