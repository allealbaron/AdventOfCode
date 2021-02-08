using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task01
{
    class Program
    {
        /// <summary>
        /// Input
        /// </summary>
        static string input = String.Empty;

        /// <summary>
        /// Given a char, returns 1 if it is equal to '(',
        /// -1 otherwise
        /// </summary>
        /// <param name="s">char</param>
        /// <returns>1 or -1</returns>
        static int DecodeSymbol(char s)
        {
            if (s.Equals('('))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
            int result = (from c in input.ToCharArray().ToList()
                          select DecodeSymbol(c)).Sum();

            Console.WriteLine("Solution 1: {0}", result);

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            int cont = 0;

            int i = 0;

            while (cont >= 0 && i < input.Length)
            {
                cont += DecodeSymbol(input[i]);
                i++;
            }

            Console.WriteLine("Solution 2: {0}", i);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            input = File.ReadAllText(fileName);
        }

        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt", "Input.txt" };

            foreach (string file in files)
            {
                Console.WriteLine("Testing file {0}", file);
                Console.WriteLine();
                Console.WriteLine();

                LoadFile(file);
                FirstPart();
                SecondPart();

                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
