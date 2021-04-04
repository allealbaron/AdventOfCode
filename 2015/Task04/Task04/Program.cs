using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode
{
    public abstract class Task04
    {
        /// <summary>
        /// Input
        /// </summary>
        public const string INPUT = "yzbqklnj";

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
            
            StringBuilder sb = new ();
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
            return GetHash(input).Substring(0,zeroes).Equals(new string('0', zeroes));
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
        /// Returns if the hash has six zeroes
        /// </summary>
        /// <param name="input">Text to get the hash</param>
        /// <returns>True if the hash has six leading zeros</returns>
        public static bool HastSixZeroes(string input)
        {
            return HasLeadingZeros(input, 6);
        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <param name="input">String to analyze</param>
        /// <returns>Value</returns>
        public static int FirstPart(string input)
        {
            int i = 1;

            while (!HasFiveZeroes(String.Format("{0}{1}", input, i.ToString())))
            {
                i++;
            }

            return i;

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <param name="input">String to analyze</param>
        /// <returns>Value</returns>
        public static int SecondPart(string input)
        {

            int i = 1;

            while (!HastSixZeroes(String.Format("{0}{1}", input, i.ToString())))
            {
                i++;
            }

            return i;
        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Console.WriteLine("First Part: {0}", FirstPart(INPUT));

            Console.WriteLine("Second Part: {0}", SecondPart(INPUT));

        }
    }
}

