using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Task01
    {
        /// <summary>
        /// Input
        /// </summary>
        public string input = String.Empty;

        /// <summary>
        /// Given a char, returns 1 if it is equal to '(',
        /// -1 otherwise
        /// </summary>
        /// <param name="s">char</param>
        /// <returns>1 or -1</returns>
        public static int DecodeSymbol(char s)
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
        /// <returns>Value</returns>
        public int FirstPart()
        {
            return (from c in input.ToCharArray().ToList()
                          select DecodeSymbol(c)).Sum();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            int cont = 0;
            int i = 0;

            while (cont >= 0 && i < input.Length)
            {
                cont += DecodeSymbol(input[i]);
                i++;
            }

            return i;
    
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            input = File.ReadAllText(fileName);
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
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task01 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
