using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task04
    {

        /// <summary>
        /// List of PassportInformation
        /// </summary>
        private readonly List<PassportInformation> passports = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>result</returns>
        public int FirstPart()
        {
            return passports.Where(p => p.IsValid()).Count();
        }

        /// <summary>
        /// Second part
        /// </summary>
        /// <returns>result</returns>
        public int SecondPart()
        {
            return passports.Where(p => p.IsValidSecondPart()).Count();
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            passports.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            PassportInformation pi = new();

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Equals(String.Empty))
                {
                    passports.Add(pi);
                    pi = new PassportInformation();
                }
                else
                {
                    foreach (string s in line.Split(' '))
                    {
                        string[] item = s.Split(':');
                        PassportInformation.Category c = (PassportInformation.Category) Enum.Parse(typeof(PassportInformation.Category), item[0]);

                        switch (c)
                        {
                            case PassportInformation.Category.byr:
                                pi.BirthYear = int.Parse(item[1]);
                                break;
                            case PassportInformation.Category.cid:
                                pi.CountryId = item[1];
                                break;
                            case PassportInformation.Category.ecl:
                                pi.EyeColor = item[1];
                                break;
                            case PassportInformation.Category.eyr:
                                pi.ExpirationYear = int.Parse(item[1]);
                                break;
                            case PassportInformation.Category.hcl:
                                pi.HairColor = item[1];
                                break;
                            case PassportInformation.Category.hgt:
                                pi.Height = item[1];
                                break;
                            case PassportInformation.Category.iyr:
                                pi.IssueYear = int.Parse(item[1]);
                                break;
                            case PassportInformation.Category.pid:
                                pi.PassportId = item[1];
                                break;
                        }

                    }
                }
            }

            passports.Add(pi);

            sr.Close();
            fs.Close();


        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task04(string fileName)
        {
            LoadFile(fileName);
        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task04 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
