using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task8
{
    class Program
    {

        /// <summary>
        /// Expenses
        /// </summary>
        static VideogameProgram videogame = new VideogameProgram();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
         
            Console.WriteLine("First solution:");

            Console.WriteLine("Accumulator: {0}", videogame.ExecuteProgram());

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {
          
            Console.WriteLine("Second solution:");

            Console.WriteLine("Execute With Debug, Accumulator: {0}", videogame.ExecuteWithDebug());
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            videogame = new VideogameProgram();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                Regex regularExpression = new Regex(@"(?<Command>(nop|acc|jmp){1})\s?(?<Movement>[+-]{1}[\d]+)");

                Match match = regularExpression.Match(line);

                if (match.Success)
                {

                    Enum.TryParse(match.Groups["Command"].Captures.First().Value, out CommandExecution.Operation command);

                    videogame.Program.Add(new CommandExecution()
                    {
                        Command = command,
                        Movements = int.Parse(match.Groups["Movement"].Captures.First().Value)
                    });
                }

            }
            sr.Close();
            fs.Close();


        }

        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt", "Input.txt" };

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
