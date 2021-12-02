using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task02
    {

        /// <summary>
        /// Expenses
        /// </summary>
        private readonly List<SubmarineCommand> commands = new();

        /// <summary>
        /// Horizontal Position
        /// </summary>
        private int horizontalPosition = 0;

        /// <summary>
        /// Depth
        /// </summary>
        private int depth = 0;

        /// <summary>
        /// Aim
        /// </summary>
        private int aim = 0;

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            horizontalPosition = (from c in commands where c.Command == SubmarineCommand.CommandType.forward select c.Amount).Sum();

            depth = -(from c in commands where c.Command == SubmarineCommand.CommandType.up select c.Amount).Sum();

            depth += (from c in commands where c.Command == SubmarineCommand.CommandType.down select c.Amount).Sum();

            return horizontalPosition * depth;

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            foreach (SubmarineCommand c in commands)
            {
                switch (c.Command)
                {
                    case SubmarineCommand.CommandType.forward:
                        horizontalPosition += c.Amount;
                        depth += c.Amount * aim;
                        break;
                    case SubmarineCommand.CommandType.up:
                        aim -= c.Amount;
                        break;
                    case SubmarineCommand.CommandType.down:
                        aim += c.Amount;
                        break;
                }
            }

            return horizontalPosition * depth;

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            commands.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(" ");
                commands.Add(new SubmarineCommand(parts[0], int.Parse(parts[1])));
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
