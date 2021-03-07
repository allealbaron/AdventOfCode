using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task01
{
    class Program
    {

        /// <summary>
        /// List of entiries
        /// </summary>
        static List<int> Entries = new List<int>();

        /// <summary>
        /// Calculates fuel necessary for the first part
        /// </summary>
        /// <param name="mass">Mass</param>
        /// <returns>Fuel necessary</returns>
        static int CalculateFuelFirstPart(int mass)
        {
            return int.Parse(Math.Floor((decimal)(mass / 3)).ToString()) -2;
        }

        /// <summary>
        /// Calculates fuel necessary for the second part
        /// </summary>
        /// <param name="mass">Mass</param>
        /// <returns>Fuel necessary</returns>
        static int CalculateFuelSecondPart(int mass)
        {

            int result = 0;

            while (mass > 2)
            {
                
                int nextValue = CalculateFuelFirstPart(mass);

                if (nextValue > 0)
                {
                    result += nextValue;
                }
                
                mass = nextValue;

            }

            return result;

        }

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {

            Console.WriteLine("First solution:");
            Console.WriteLine("Necessary fuel: {0}", (from t in Entries select CalculateFuelFirstPart(t)).Sum());

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            Console.WriteLine("Second solution:");
            Console.WriteLine("Necessary fuel: {0}", (from t in Entries select CalculateFuelSecondPart(t)).Sum());

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {

            Entries = new List<int>();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                Entries.Add(int.Parse(line));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt" , "Input.txt" };

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
