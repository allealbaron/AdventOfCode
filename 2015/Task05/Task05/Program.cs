using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task05
    {

        /// <summary>
        /// Forbidden strings
        /// </summary>
        private static readonly List<string> forbiddenStrings = new() { "ab", "cd", "pq", "xy"};

        /// <summary>
        /// Input
        /// </summary>
        private readonly List<string> input = new();

        /// <summary>
        /// Evaluates if a char is a vowel
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns>True if it is a vowel</returns>
        public static bool IsVowel(char c)
        {
            return (c.Equals('a') || c.Equals('e') || c.Equals('i') || c.Equals('o') || c.Equals('u'));
        }

        /// <summary>
        /// Checks if a string has at least three vowels
        /// </summary>
        /// <param name="input">String</param>
        /// <returns>True if the string has at least three vowels</returns>
        public static bool ContainsAtLeastThreeVowels(string input)
        {
            return (from c in input.ToCharArray()
                    where IsVowel(c)
                    select c).Count() >= 3;

        }

        /// <summary>
        /// Checks if a string has a repeated character
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns>True if the string has a repeated character</returns>

        public static bool ContainsRepeatedChar(string input)
        {

            bool result = false;

            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i].Equals(input[i + 1]))
                {
                    return true;
                }
            }

            return result;

        }

        /// <summary>
        /// Checks if a string contains at least one of the
        /// forbidden strings
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns>True if input contains at least one of the
        /// forbidden strings</returns>
        public static bool ContainsForbiddenStrings(string input)
        {

            return ((from fb in forbiddenStrings
                    where input.Contains(fb)
                    select fb).Any());

        }

        /// <summary>
        /// Checks if a string is nice
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns>True if the string is nice</returns>
        public static bool IsNice(string input)
        {
            return ContainsAtLeastThreeVowels(input) &&
                   ContainsRepeatedChar(input) &&
                   !ContainsForbiddenStrings(input);
        }

        /// <summary>
        /// Checks if a string has a repeated pair
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns>True if the string has a repeated pair</returns>

        public static bool ContainsRepeatedPair(string input)
        {

            bool result = false;

            for (int i = 0; i < input.Length - 2; i++)
            {

                if (input[(i + 2)..].Contains(input.Substring(i, 2)))
                {
                    return true;
                }

            }

            return result;

        }

        /// <summary>
        /// Checks if a string has a repeated character with a different
        /// char in the middle
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns>True if the string has a repeated character</returns>

        public static bool ContainsRepeatedCharWithMiddle(string input)
        {

            bool result = false;

            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i].Equals(input[i + 2]))
                {
                    return true;
                }
            }

            return result;

        }

        /// <summary>
        /// Checks if a string is nice (Second part)
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns>True if the string is nice</returns>
        public static bool IsNiceSecondPart(string input)
        {
            return ContainsRepeatedCharWithMiddle(input) &&
                   ContainsRepeatedPair(input);
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
                input.Add(line);
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task05(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public  int FirstPart()
        {

            return input.Where(p => IsNice(p)).Count();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            return input.Where(p => IsNiceSecondPart(p)).Count();

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task05 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}

