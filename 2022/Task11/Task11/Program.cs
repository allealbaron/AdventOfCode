using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2022
{
    public class Task11
    {

        /// <summary>
        /// Monkeys
        /// </summary>
        private readonly IList<Monkey> _monkeys = new List<Monkey>();


        private long ExecuteRounds(int rounds, int reliefFactor)
        {

            for (var i = 0; i < rounds; i++)
            {
                foreach (var monkey in _monkeys)
                {
                    monkey.CompleteEvaluation(reliefFactor);
                }
            }

            var topResults = _monkeys
                .OrderByDescending(t => t.Inspections)
                .Take(2).Select(t => t.Inspections).ToList();

            return (topResults[0] * topResults[1]);

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public long FirstPart()
        {

            const int RELIEF_FACTOR_FIRST_PART = 3;
            const int ROUNDS_FIRST_PART = 20;

            return ExecuteRounds(ROUNDS_FIRST_PART, RELIEF_FACTOR_FIRST_PART);
            
        }

        /// <summary>
        /// Second part
        /// </summary>
        public long SecondPart()
        {

            const int RELIEF_FACTOR_SECOND_PART = 1;
            const int ROUNDS_SECOND_PART = 10000;

            return ExecuteRounds(ROUNDS_SECOND_PART, RELIEF_FACTOR_SECOND_PART);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            _monkeys.Clear();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            string line;

            while ((line = sr.ReadLine()) != null)
            {

                if (string.IsNullOrEmpty(line))
                {
                    line = sr.ReadLine();
                }

                var monkeyId = int.Parse(line.Split(" ")[1].Replace(":", string.Empty));

                line = sr.ReadLine();
                var startingItems = new Queue<long>();

                foreach (var item in line.Split(":")[1].Split(","))
                {
                    startingItems.Enqueue(long.Parse(item.Trim()));
                }

                line = sr.ReadLine();
                var operationPart = line.Split("=")[1].Trim().Split(" ");

                var operation = new Operation(operationPart[1],
                                        operationPart[2] == "old" ? null : long.Parse(operationPart[2]));

                line = sr.ReadLine();
                var testDivisible = int.Parse(line.Split("by")[1].Trim());

                line = sr.ReadLine();
                var trueMonkeyId = int.Parse(line.Split("monkey")[1].Trim());

                line = sr.ReadLine();
                var falseMonkeyId = int.Parse(line.Split("monkey")[1].Trim());

                _monkeys.Add(new Monkey
                    (
                        _monkeys,
                        monkeyId,
                        startingItems,
                        operation,
                        testDivisible,
                        trueMonkeyId,
                        falseMonkeyId
                    ));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task11(string fileName)
        {

            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            var fileName = "Input.txt";

            Task11 t = new(fileName);

            Console.WriteLine("First Part: {0}", t.FirstPart());
            
            
            t = new(fileName);

            Console.WriteLine("Second Part: {0}", t.SecondPart());
            
        }

    }
}
