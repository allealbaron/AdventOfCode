using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task19
{
    class Program
    {
        /// <summary>
        /// Rules
        /// </summary>
        static Dictionary<int, string> Rules = new Dictionary<int, string>();

        /// <summary>
        /// Strings to check
        /// </summary>
        static List<string> CheckList = new List<string>();

        /// <summary>
        /// Generates a grammar
        /// </summary>
        static private void GenerateGrammar()
        {
            bool blnFound = true;

            while (blnFound)
            {
                blnFound = false;

                int i = Rules.Keys.Max();

                while (i >= 0)
                {

                    foreach (KeyValuePair<int, string> kvpIntern in (
                    from r in Rules
                    where
                        r.Value.Contains(i.ToString())
                    select
                        new KeyValuePair<int, string>(
                            r.Key, r.Value.Replace(i.ToString(), Rules[i]))).ToList())
                    {
                        blnFound = true;
                        Rules[kvpIntern.Key] = kvpIntern.Value;
                    }

                    i--;

                }

            }

            int j = Rules.Keys.Max();
            while (j >= 0)
            {
                if (Rules.ContainsKey(j))
                {
                    Rules[j] = Rules[j].Replace(" ", String.Empty);
                }
                j--;
            }

        }

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {

            GenerateGrammar();

            Regex regex = new Regex("^" + Rules[0] + "$");

            int solutionFirstPart = (from s in CheckList
                    where regex.IsMatch(s)
                    select s).Count();


                Console.WriteLine("First solution: {0}", solutionFirstPart);

        }

        /// <summary>
        /// Generates Rule 11 with <paramref name="n"/> repetitions
        /// </summary>
        /// <param name="n">Repetitions</param>
        /// <returns>Rule11</returns>
        static string GenerateRule11(int n)
        {
            StringBuilder builder = new StringBuilder("(");

            for (int j = 1; j < n; j++)
            {
                
                builder.Append("(");

                for (int i = 0; i < j; i++)
                {
                    builder.Append("42 ");
                }

                for (int i = 0; i < j; i++)
                {
                    builder.Append(" 31");
                }
                builder.Append(")");

                if (j != n - 1)
                {
                    builder.Append("|");
                }

            }

            builder.Append(")");

            return builder.ToString();

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {
            //8: 42 | 42 8
            // 11: 42 31 | 42 11 31

            // Rules[11] shall be something like 42 (42){n} 31(n) 31
            // Since I am not able to create this regex, I would generate manually
            // 42 (42){n} 31(n) 31 and check every time if the number of matches change

            // 381 is the solution

            int n = 8;

            int solutionSecondPart = 0;

            bool blnLoop = true;

            Rules[8] = "(42)+";

            while (blnLoop)
            {

                Rules[11] = GenerateRule11(n);

                GenerateGrammar();

                blnLoop = false;

                Regex regex = new Regex("^" + Rules[0] + "$");

                int temp = (from s in CheckList
                            where regex.IsMatch(s)
                            select s).Count();

                if (temp > solutionSecondPart)
                {
                    solutionSecondPart = temp;
                    blnLoop = true;
                }
                n++;
            }

            Console.WriteLine("Second solution: {0}", solutionSecondPart);


        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            Rules = new Dictionary<int, string>();
            CheckList = new List<string>();


            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            Regex regex = new Regex(@"((?<RuleId>((\d))+)):\s(?<RulePred>[\s|(\d)+)|(\|\s(\d)+)|([(a|b){1})]+)");

            while (((line = sr.ReadLine()) != null) && !line.Equals(String.Empty))
            {
                line = line.Replace("\"", String.Empty);

                Match match = regex.Match(line);

                string pred = match.Groups["RulePred"].Value;

                if (pred.Contains('|'))
                {
                    pred = String.Format("({0})", pred);
                }

                Rules.Add(int.Parse(match.Groups["RuleId"].Value), pred);

            }

            while ((line = sr.ReadLine()) != null)
            {
                CheckList.Add(line);
            }

            sr.Close();
            fs.Close();


        }

        static void Main()
        {
            List<string> files = new List<string>() {"TestInput.txt", "TestInput2.txt", "TestInput3.txt", "Input.txt" };

            foreach (string file in files)
            {
                Console.WriteLine("Testing file {0}", file);
                Console.WriteLine();
                Console.WriteLine();

                LoadFile(file);
                FirstPart();

                if (file.Equals("Input.txt") || file.Equals("TestInput3.txt"))
                {
                    LoadFile(file);
                    SecondPart();
                }

                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
