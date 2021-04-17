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
        /// Input
        /// </summary>
        private readonly List<ChristmasPackage> ChristmasPackages = new ();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {
            return (from c in ChristmasPackages
                          select c.GetWrapping()).Sum();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            return (from c in ChristmasPackages
                          select c.GetRibbonLength()).Sum();


        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private  void LoadFile(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new (fs, Encoding.UTF8, true, BufferSize);
            String line;

            Regex regex = new (@"(?<Length>^\d+)(x)(?<Width>\d+)(x)(?<Height>\d+)$");

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
