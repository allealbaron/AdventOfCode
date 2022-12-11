using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2022
{
    public class Task10
    {

        private const int SCREEN_WIDTH = 40;

        /// <summary>
        /// Commands
        /// </summary>
        private readonly IList<Command> _commands = new List<Command>();

        /// <summary>
        /// X position in every cycle
        /// </summary>
        private readonly IList<int> _X = new List<int>();

        private IList<Tuple<Step, int>> GetNextCommands()
        {

            var result = new List<Tuple<Step, int>>();

            foreach (var c in _commands)
            {
                if (c.Type == Command.CommandType.Add)
                {
                    result.Add(new Tuple<Step, int>(Step.Step0, c.Value));
                    result.Add(new Tuple<Step, int>(Step.Step1, c.Value));
                }
                else
                {
                    result.Add(new Tuple<Step, int>(Step.Step0, c.Value));
                }

            }

            return result;

        }

        /// <summary>
        /// Executes commands
        /// </summary>
        private void ExecuteCommands()
        {

            var buffer = 0;

            foreach (var x in GetNextCommands())
            {
                if (x.Item1 == Step.Step0)
                {
                    if (_X.Count == 0)
                    {
                        _X.Add(1);
                    }
                    else
                    {
                        _X.Add(_X.Last() + buffer);
                        buffer = 0;
                    }
                }
                else
                {
                    buffer = x.Item2;

                    if (_X.Count == 0)
                    {
                        _X.Add(1);
                    }
                    else
                    {
                        _X.Add(_X.Last());
                    }
                }
            }

            _X.Add(_X.Last()+buffer);

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            var result = 0;

            for (var i = 0; i < 6; i++)
            {
                int position = (int)Math.Round((i + 0.5) * SCREEN_WIDTH);

                result += _X[position - 1] * position;
            }

            return result;

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            var line = new StringBuilder();

            for (var i = 0; i < _X.Count; i++)
            {

                var x = _X[i];

                var value = i % SCREEN_WIDTH;

                var charSelected = (value >= (x - 1) && value <= (x + 1))
                                    ? '#'
                                    : '.';

                line.Append(charSelected);

                if (i % SCREEN_WIDTH == 0)
                {
                    Console.WriteLine();
                }

                Console.Write(charSelected);

            }

            return 0;

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            _commands.Clear();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
               
                var parts = line.Split(' ');

                if (parts[0] == "noop")
                {
                    _commands.Add(new Command(0));
                }
                else
                {
                    _commands.Add(new Command(int.Parse(parts[1])));
                }

            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task10(string fileName)
        {

            LoadFile(fileName);

            ExecuteCommands();

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            var fileName = "Input.txt";

            Task10 t = new(fileName);

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
