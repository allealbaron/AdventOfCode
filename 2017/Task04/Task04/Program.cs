using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task04
    {

        /// <summary>
        /// Input
        /// </summary>
        private readonly List<List<string>> input = new();

        /// <summary>
        /// Checks if a passphrase is valid (0 words repeated)
        /// </summary>
        /// <param name="passphrase">Passphrase</param>
        /// <returns>True if valid</returns>
        private static bool CheckValidPassphrasePart1(List<string> passphrase)
        {

            HashSet<string> testHashSet = new();

            foreach (string s in passphrase)
            {
                if (testHashSet.Contains(s))
                {
                    return false;
                }
                else
                {
                    testHashSet.Add(s);
                }
            }

            return true;

        }

        /// <summary>
        /// Checks if a passphrase is valid (no word is another's anagram)
        /// </summary>
        /// <param name="passphrase">Passphrase</param>
        /// <returns>True if valid</returns>
        private static bool CheckValidPassphrasePart2(List<string> passphrase)
        {

            HashSet<string> testHashSet = new();

            foreach (string s in passphrase)
            {
                List<char> tempList = s.ToList<char>();
                
                tempList.Sort();

                string sortedWord = new (tempList.ToArray());

                if (testHashSet.Contains(sortedWord))
                {
                    return false;
                }
                else
                {
                    testHashSet.Add(sortedWord);
                }
            }

            return true;

        }


        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                input.Add(line.Split(' ').ToList());
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task04(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {
            return (from p in input where CheckValidPassphrasePart1(p) select p).Count();
        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {
            return (from p in input where CheckValidPassphrasePart2(p) select p).Count();
        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task04 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
