using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task9
{
    class Program
    {

        /// <summary>
        /// Data
        /// </summary>
        static List<Int64> Data = new List<Int64>();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart(int overlay)
        {

                Console.WriteLine("First solution:");
                Console.WriteLine("{0}", GetNotFoundNumber(overlay));
            
        }

        static private Int64 GetNotFoundNumber(int overlay)
        {
            int i, j, k;

            k = 0;
            bool blnFound = true;

            while (blnFound && k < Data.Count)
            {
                blnFound = false;

                i = k;

                while (!blnFound && i < k + overlay)
                {
                    j = i + 1;

                    while (!blnFound && j < k + overlay)
                    {
                        blnFound = (Data[k + overlay] == Data[i] + Data[j]);
                        j++;
                    }
                    i++;
                }

                k++;
            }

            return Data[k + overlay - 1];

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart(int overlay)
        {

            Int64 NotFoundNumber = GetNotFoundNumber(overlay);
            
            List<Int64> solution = new List<Int64>();

            int i = 0;

            while (i < Data.Count)
            {
                solution.Clear();
                int j = i;

                while (solution.Sum() < NotFoundNumber)
                {
                    solution.Add(Data[j]);
                    j++;
                }

                if (solution.Sum() == NotFoundNumber)
                {
                    i = Data.Count;
                }

                i++;

            }

            Console.WriteLine("Second solution:");
            Console.WriteLine("Min: {0}", solution.Min());
            Console.WriteLine("Max: {0}", solution.Max());
            Console.WriteLine("Solution: {0}", solution.Min()+ solution.Max());

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            Data = new List<Int64>();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                Data.Add(Int64.Parse(line));
            }

            sr.Close();
            fs.Close();

        }

        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt" , "Input.txt" };
            int overlay = 5;
            foreach (string file in files)
            {
                Console.WriteLine("Testing file {0}", file);
                Console.WriteLine();
                Console.WriteLine();

                LoadFile(file);
                FirstPart(overlay);
                SecondPart(overlay);

                Console.WriteLine();
                Console.WriteLine();

                overlay *= overlay;
    }

        }
    }
}
