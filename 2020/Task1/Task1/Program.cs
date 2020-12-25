using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {

        /// <summary>
        /// Expenses
        /// </summary>
        static List<int> expenses = new List<int>();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
            var innerJoin = from i in expenses
                            join j in expenses
                            on
                                i equals 2020 - j
                            where
                                i>j
                            select new { i, j };

            Console.WriteLine("First solution:");

            foreach (var item in innerJoin)
            {
                Console.WriteLine("{0} + {1} = 2020", item.i, item.j);
                Console.WriteLine("Solution 1: {0}", item.i * item.j);
            }

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {
            var innerJoin = from e1 in expenses
                            from e2 in expenses
                            from e3 in expenses
                            where (2020 == (e1+ e2 + e3)
                            && e1>e2 && e2>e3)
                            select new { e1, e2, e3 };

            Console.WriteLine("Second solution:");

            foreach (var item in innerJoin)
            {
                Console.WriteLine("{0} + {1} + {2} = 2020", item.e1, item.e2, item.e3);
                Console.WriteLine("Solution 2: {0}", item.e1 * item.e2 * item.e3);
            }

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            expenses = new List<int>();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                expenses.Add(int.Parse(line));
            }

            sr.Close();
            fs.Close();


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
