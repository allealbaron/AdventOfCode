using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task02
    {
        /// <summary>
        /// Input
        /// </summary>
        private readonly List<string> input = new();

        /// <summary>
        /// Checks if a string contains a char a number of times
        /// </summary>
        /// <param name="inputString">Input</param>
        /// <param name="number">Number</param>
        /// <returns>True if <paramref name="inputString"/> contains at least one char repeated <paramref name="number"/> characters</returns>
        public static bool ContainRepeatedChars(string inputString, int number)
        {

            return  inputString.ToCharArray()
                        .GroupBy(n => n, (key, values) => new { Notice = key, Count = values.Count() })
                        .Where(n=> n.Count == number).Any();

        }

        /// <summary>
        /// Returns the number of different characters between two strings
        /// </summary>
        /// <param name="string1">Input</param>
        /// <param name="string2">Number</param>
        /// <returns>Number of different characters between two strings</returns>
        public static int GetNumberDifferentCharacters(string string1, string string2)
        {
            return (from s1 in string1.ToCharArray().Select((v, i) => new { c = v, index = i })
                    from s2 in string2.ToCharArray().Select((v, i) => new { c = v, index = i })
                    where !(s1.c.Equals(s2.c)) && s1.index == s2.index
                    select s1.c).Count();
        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {
            return (from i in input where ContainRepeatedChars(i, 2) select i).Count() *
                   (from i in input where ContainRepeatedChars(i, 3) select i).Count();
        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public string SecondPart()
        {
            var pair = (from s1 in input
                     from s2 in input
                     where GetNumberDifferentCharacters(s1, s2) == 1
                     select (s1, s2)).First();

            return  String.Concat(from s1 in pair.s1.ToCharArray().Select((v, i) => new { c = v, index = i })
                    from s2 in pair.s2.ToCharArray().Select((v, i) => new { c = v, index = i })
                    where (s1.c.Equals(s2.c)) && s1.index == s2.index
                    select s1.c);

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
        public Task02(string fileName)
        {


            LoadFile(fileName);

        }

        static void Main()
        {

            Task02 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
