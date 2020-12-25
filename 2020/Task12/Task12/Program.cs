using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task12
{
    class Program
    {

        /// <summary>
        /// Cruise
        /// </summary>
        static Cruise Cruise = new Cruise();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {


            Cruise.NavigateFirstPart();

            Console.WriteLine("First solution: {0}", Cruise.GetManhattanDistance());



        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            Cruise.NavigateSecondPart();

            Console.WriteLine("Second solution: {0}", Cruise.GetManhattanDistance());

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            Cruise = new Cruise();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                Cruise.Movements.Add(new Movement()
                {
                    Move = (Movement.MoveEnum) Enum.Parse(typeof(Movement.MoveEnum), line[0].ToString()),
                    Quantity = int.Parse(line.Substring(1))
                }); ; ;
            }

            sr.Close();
            fs.Close();


        }

        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt", 
                "Input.txt" };

            foreach (string file in files)
            {
                Console.WriteLine("Testing file {0}", file);
                Console.WriteLine();
                Console.WriteLine();

                LoadFile(file);
                FirstPart();
                LoadFile(file);
                SecondPart();

                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
