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
        /// Input
        /// </summary>
        static List<ChristmasPackage> ChristmasPackages = new List<ChristmasPackage>();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
            int result = (from c in ChristmasPackages
                          select c.GetWrapping()).Sum();

            Console.WriteLine("Solution 1: {0}", result);

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            int result = (from c in ChristmasPackages
                          select c.GetRibbonLength()).Sum();

            Console.WriteLine("Solution 2: {0}", result);


        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {

            ChristmasPackages = new List<ChristmasPackage>();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            Regex regex = new Regex(@"(?<Length>^\d+)(x)(?<Width>\d+)(x)(?<Height>\d+)$");

            while ((line = sr.ReadLine()) != null)
            {

                Match lineMatch = regex.Match(line);

                ChristmasPackages.Add(new ChristmasPackage()
                                    { 
                                        Height = int.Parse(lineMatch.Groups["Height"].Captures[0].Value),
                                        Width = int.Parse(lineMatch.Groups["Width"].Captures[0].Value),
                                        Length = int.Parse(lineMatch.Groups["Length"].Captures[0].Value),

                                    });
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
