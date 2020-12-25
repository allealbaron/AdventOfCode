using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task02
{
    class Program
    {

        /// <summary>
        /// Expenses
        /// </summary>
        static List<PasswordPolicy> passwords = new List<PasswordPolicy>();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {


           Console.WriteLine("First solution:");

           Console.WriteLine("Ok items: {0}", passwords.Where(t=> t.IsValidFirstPart()).Count());
        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            Console.WriteLine("Second solution:");

            Console.WriteLine("Ok items: {0}", passwords.Where(t => t.IsValidSecondPart()).Count());

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {

            if (File.Exists(fileName))
                {

                passwords = new List<PasswordPolicy>();

                const Int32 BufferSize = 128;
                FileStream fs = File.OpenRead(fileName);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
                String line;

                Regex regExpression = new Regex(@"(\d+)-(\d+)\s(\D):\s([0-9a-z]+)");

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

        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt", "Input.txt" };

            foreach (string file in files)
            {
                Console.WriteLine("Probando fichero {0}", file);
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
