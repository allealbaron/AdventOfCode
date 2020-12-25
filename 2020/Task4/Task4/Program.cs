using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task4
{
    class Program
    {

        /// <summary>
        /// List of PassportInformation
        /// </summary>
        static List<PassportInformation> passports = new List<PassportInformation>();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
         
            Console.WriteLine("First solution:");
            Console.WriteLine("Valid passwords: {0}", passports.Where(p => p.IsValid()).Count());

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            var x = passports.Where(p => p.IsValidSecondPart()).ToList();


            Console.WriteLine("Second solution:");
            Console.WriteLine("Valid passwords: {0}", passports.Where(p => p.IsValidSecondPart()).Count());

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            passports = new List<PassportInformation>();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            PassportInformation pi = new PassportInformation();

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
