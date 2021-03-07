using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task02
{
    class Program
    {

        /// <summary>
        /// List of entiries
        /// </summary>
        static List<int> Entries = new List<int>();


        /// <summary>
        /// Computes First Part
        /// </summary>
        /// <returns>Value stored at position 0</returns>
        static int ComputeFirstPart()
        {

            int i = 0;

            while (Entries[i] != 99)
            {
                switch (Entries[i])
                {
                    case 1:
                        Entries[Entries[i + 3]] = (Entries[Entries[i + +1]] + Entries[Entries[i + 2]]);
                        i += 4;
                        break;
                    case 2:
                        Entries[Entries[i + 3]] = (Entries[Entries[i + +1]] * Entries[Entries[i + 2]]);
                        i += 4;
                        break;
                }
            }

            return Entries[0];

        }

        /// <summary>
        /// Computes Second Part
        /// </summary>
        /// <returns>Result</returns>
        static int ComputeSecondPart()
        {
            const int GOAL = 19690720;

            int result = 0;
            int noun = 0;
            int verb = 0;

            while (result != GOAL && verb<100)
            {
                LoadFile("Input.txt");

                Entries[1] = noun;
                Entries[2] = verb;

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
        static void FirstPart()
        {

            Console.WriteLine("First solution:");
            Console.WriteLine("Value at position 0: {0}", ComputeFirstPart());

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            Console.WriteLine("Second solution:");
            Console.WriteLine("Answer: {0}", ComputeSecondPart());

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {

            Entries = new List<int>();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            line = sr.ReadLine();

            foreach( string s in line.Split(","))
            { 
                Entries.Add(int.Parse(s));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt" , "TestInput2.txt", "TestInput3.txt", 
                                                       "TestInput4.txt", "TestInput5.txt", "Input.txt" };

            foreach (string file in files)
            {
                Console.WriteLine("Testing file {0}", file);
                Console.WriteLine();
                Console.WriteLine();

                LoadFile(file);

                if (file == "Input.txt")
                {
                    Entries[1] = 12;
                    Entries[2] = 2;
                }

                FirstPart();

                if (file == "Input.txt")
                {
                    SecondPart();
                }

                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
