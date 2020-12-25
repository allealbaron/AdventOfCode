using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task3
{
    class Program
    {

        /// <summary>
        /// Expenses
        /// </summary>
        static List<string> lines = new List<string>();


        /// <summary>
        /// Calculates how many trees does the user hit
        /// </summary>
        /// <param name="horizontalMoves">Horizontal moves</param>
        /// <param name="verticalMoves">Vertical moves</param>
        /// <returns></returns>
        static int MoveThroughForest(int horizontalMoves, int verticalMoves)
        {
            int result = 0;
            int j = 0;

            for (int i = 0; i < lines.Count; i+=verticalMoves)
            {
                if (lines[i][j % lines[i].Length] == '#')
                {
                    result++;
                }
                j += horizontalMoves;
            }

            return result;
        }

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {

            Console.WriteLine("First solution:");

            Console.WriteLine("Resultado : {0}", MoveThroughForest(3,1));

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {
          
            List<(int, int)> parameters = new List<(int, int)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };

            Console.WriteLine("Second solution:");

            Console.WriteLine("Resultado : {0}", parameters.Select(tuple => MoveThroughForest(tuple.Item1, tuple.Item2))
                                    .Aggregate((uint)1, (acc, val) => (uint)acc * (uint)val).ToString());
         
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            lines = new List<string>();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
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
