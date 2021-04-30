using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode
{
    public class Task05
    {

        /// <summary>
        /// Input
        /// </summary>
        private readonly string input;

        /// <summary>
        /// Calculates MD5 hash
        /// </summary>
        /// <param name="input">Text to get its hash</param>
        /// <returns>Returns its hash</returns>
        public static string GetHash(string input)
        {

            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();

        }

        /// <summary>
        /// Returns if the hash has six zeroes
        /// </summary>
        /// <param name="input">Text to get the hash</param>
        /// <param name="zeroes">Number of zeroes to find</param>
        /// <returns>True if the hash has the number of leading zeros</returns>
        public static bool HasLeadingZeros(string input, int zeroes)
        {
            return GetHash(input).Substring(0, zeroes).Equals(new string('0', zeroes));
        }

        /// <summary>
        /// Returns if the hash has five zeroes
        /// </summary>
        /// <param name="input">Text to get the hash</param>
        /// <returns>True if the hash has five leading zeros</returns>
        public static bool HasFiveZeroes(string input)
        {
            return HasLeadingZeros(input, 5);
        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public string FirstPart()
        {

            int i = 1;

            List<string> results = new();

            StringBuilder result = new();

            while (results.Count<8)
            {
                if (HasFiveZeroes(String.Format("{0}{1}", input, i.ToString())))
                {
                    results.Add(GetHash(String.Format("{0}{1}", input, i.ToString())));
                }
                i++;
            }

            foreach (string s in results)
            {
                result.Append(s[5]);
            }

            return result.ToString().ToLower();
         
        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public string SecondPart()
        {
            int i = 1;

            char[] result = new char[8];

            while ((from c in result where c == 0 select c).Any())
            {
                if (HasFiveZeroes(String.Format("{0}{1}", input, i.ToString())))
                {
                    string possibleSolution = GetHash(String.Format("{0}{1}", input, i.ToString())).ToLower();

                    if ((from c in "01234567".ToCharArray() where c == possibleSolution[5] select c).Any())
                    {
                        int position = int.Parse(possibleSolution[5].ToString());
                        if (result[position] == 0)
                        {
                            result[position] = possibleSolution[6];
                        }
                    }

                }
                i++;
            }

            return String.Concat(result);

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="input">Input</param>
        public Task05(string input)
        {

            this.input = input;

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {

            Task05 t = new("ugkcyxxp");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}

