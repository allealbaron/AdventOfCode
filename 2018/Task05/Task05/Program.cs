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
        /// Input
        /// </summary>
        private string inputData = String.Empty;

        /// <summary>
        /// Given a string, reduces it if both characters
        /// are equal and their case (uppercase/lowcase) are different
        /// </summary>
        /// <param name="input">string to reduce</param>
        /// <returns>reduced string</returns>
        public static string ReduceString(string input)
        {
            int i = 0;

            List<char> characters = input.ToCharArray().ToList<char>();

            while (i < characters.Count-1)
            {
                if (characters[i].ToString().ToLower() == characters[i + 1].ToString().ToLower() &&
                    !characters[i].Equals(characters[i + 1]))
                {
                    characters.RemoveAt(i + 1);
                    characters.RemoveAt(i);
                    i -= 2;
                    if (i < 0)
                    {
                        i = 0;
                    }
                }
                else
                {
                    i++;
                }
            }

            return String.Concat(characters);

        }

        /// <summary>
        /// Given a string, returns the minimum reduction in case
        /// one of the letters is removed
        /// </summary>
        /// <param name="input">string to reduce</param>
        /// <returns>Minimum number after reduction</returns>
        public static int GetMinimumReduce(string input)
        {

            List<char> distinctCharacters = input.ToLower().ToCharArray().ToList<char>().Distinct().ToList();

            return (
                    from 
                        c in distinctCharacters 
                    select ReduceString(
                            input.Replace(c.ToString(), String.Empty).Replace(c.ToString().ToUpper(), String.Empty) 
                            ).Length).Min();

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            return ReduceString(this.inputData).Length;

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            return GetMinimumReduce(this.inputData);

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

            this.inputData = sr.ReadToEnd();

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

        static void Main()
        {

            Task05 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
