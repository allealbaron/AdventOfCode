using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task10
{
    class Program
    {

        /// <summary>
        /// Adapters
        /// </summary>
        static List<int> Adapters = new List<int>();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {

            var indexedAdapters = Adapters.Select((value, index) => new { value, index });

            var query = (from a1 in indexedAdapters
                        from a2 in indexedAdapters
                        where (a1.index == a2.index - 1)
                        select new {difference =  a2.value - a1.value }).GroupBy(d => d.difference)
                        .Select(group => new {
                            difference = group.Key,
                            Count = group.Count()
                        }).Aggregate(1, (acc, val) => acc * val.Count);

            Console.WriteLine("First solution: {0}", query);

           

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            List<int> combinations = new List<int>();
            int contiguousCount = 0;

            for (int i = 0; i < Adapters.Count - 1; i++)
            {
                if (Adapters[i + 1] - Adapters[i] == 1)
                {
                    contiguousCount++;
                }
                else
                {
                    contiguousCount--;
                    if (contiguousCount >= 1)
                    {
                        combinations.Add(contiguousCount);
                    }
                    contiguousCount = 0;
                }

            }
            Int64  totalCombinations = 1;
            int[] runCombinations = { 1, 2, 4, 7 };
            foreach (int c in combinations)
            {
                totalCombinations *= runCombinations[c];
            }

            Console.WriteLine("Second solution: {0}", totalCombinations);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            Adapters = new List<int>();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                Adapters.Add(int.Parse(line));
            }
            Adapters.Add(0);
            Adapters.Add(Adapters.Max() + 3);
            Adapters.Sort();

            sr.Close();
            fs.Close();


        }

        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt", "TestInput2.txt", "Input.txt" };

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
