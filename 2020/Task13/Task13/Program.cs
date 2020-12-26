using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task13
{
    class Program
    {

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart(Input input)
        {
            Console.WriteLine("First solution: {0}", input.CalculateMinimumWaitingTime());
        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart(Input input)
        {
            Console.WriteLine("Second solution: {0}", input.CalculateChineseRemainderTheorem() );
        }

        static void Main()
        {

            List<Input> inputs = new List<Input>
            {
                new Input()
                {
                    Id = "1",
                    EarliestTimeStamp = 939,
                    Schedule = { "7", "13", "x", "x", "59", "x", "31", "19" }
                },

                new Input()
                {
                    Id = "2",
                    EarliestTimeStamp = 1002462,
                    Schedule = { "37", "x", "x", "x", "x", "x", "x", "x", "x", "x", "x", "x",
                                "x", "x", "x", "x", "x", "x", "x", "x", "x", "x", "x", "x",
                                "x", "x", "x", "41", "x", "x", "x", "x", "x", "x", "x", "x",
                                "x", "601", "x", "x", "x", "x", "x", "x", "x", "x", "x", "x",
                                "x", "19", "x", "x", "x", "x", "17", "x", "x", "x", "x", "x",
                                "23", "x", "x", "x", "x", "x", "29", "x", "443", "x", "x", "x",
                                "x", "x", "x", "x", "x", "x", "x", "x", "x", "13" }
                }
            };

            foreach (Input input in inputs)
            {
                Console.WriteLine("Testing Input {0}", input.Id);
                Console.WriteLine();
                Console.WriteLine();

                input.FillModules();

                FirstPart(input);
                SecondPart(input);

                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
