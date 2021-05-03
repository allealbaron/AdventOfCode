using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Task02
    {

        /// <summary>
        /// Expenses
        /// </summary>
        private readonly List<PasswordPolicy> passwords = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Solution</returns>
        public int FirstPart()
        {
            return passwords.Where(t => t.IsValidFirstPart()).Count();
        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Solution</returns>
        public int SecondPart()
        {
            return passwords.Where(t => t.IsValidSecondPart()).Count();
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            if (File.Exists(fileName))
            {

                passwords.Clear();

                const Int32 BufferSize = 128;
                FileStream fs = File.OpenRead(fileName);
                StreamReader sr = new (fs, Encoding.UTF8, true, BufferSize);
                String line;

                Regex regExpression = new (@"(\d+)-(\d+)\s(\D):\s([0-9a-z]+)");

                while ((line = sr.ReadLine()) != null)
                {
                    GroupCollection groups = regExpression.Match(line).Groups;

                    passwords.Add(new PasswordPolicy()
                        { 
                            MinValue = int.Parse(groups[1].Value),
                            MaxValue = int.Parse(groups[2].Value),
                            Character = groups[3].Value[0],
                            PassWord = groups[4].Value
                    }
                        );

                }

                sr.Close();
                fs.Close();
            }

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task02(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task02 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
