using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task18
{
    class Program
    {

        /// <summary>
        /// Problems
        /// </summary>
        static List<string> Problems = new List<string>();

        /// <summary>
        /// Gets max parenthesis depth
        /// </summary>
        /// <param name="problem">Problem to process</param>
        /// <returns>Max parenthesis depth</returns>
        static int GetMaxDepth(string problem)
        {
            int openedParenthesisCount = 0;
            int maxParenthesisDepth = 0;

            foreach (char c in problem)
            {
                if (c.Equals('('))
                {
                    openedParenthesisCount++;
                    if (openedParenthesisCount > maxParenthesisDepth)
                    {
                        maxParenthesisDepth = openedParenthesisCount;
                    }
                }
                else
                {
                    if (c.Equals(')'))
                    {
                        openedParenthesisCount--;
                    }
                }
            }

            return maxParenthesisDepth;

        }

        /// <summary>
        /// Gets the first position where a parenthesis is in the
        /// <paramref name="maxDepth"/>
        /// </summary>
        /// <param name="problem">Problem</param>
        /// <param name="maxDepth">Max Depth</param>
        /// <returns>First position where an opening parenthesis is found</returns>
        static int GetParenthesisPosition(string problem, int maxDepth)
        {
            
            int openedParenthesisCount = 0;
            int i = 0;
            bool blnLoop = true;

            while (blnLoop && i < problem.Length)
            {
                if (problem[i].Equals('('))
                {
                    openedParenthesisCount++;
            
                    if (openedParenthesisCount.Equals(maxDepth))
                    {
                        blnLoop = false;
                        i--;
                    }

                }
                else
                {
                    if (problem[i].Equals(')'))
                    {
                        openedParenthesisCount--;
                    }
                }

                i++;

            }

            return i;

        }

        /// <summary>
        /// Process a problem
        /// </summary>
        /// <param name="problem">Line to Process</param>
        static Int64 ProcessLine(string problem, bool part2)
        {

            while (problem.IndexOf('(') >= 0)
            {
                int parenthesisIndex = GetParenthesisPosition(problem, GetMaxDepth(problem));

                string operation = problem.Substring(parenthesisIndex,
                                        problem.IndexOf(')', parenthesisIndex) - parenthesisIndex + 1);

                if (part2)
                {
                    problem = problem.Replace(operation, CalculatePart2(operation).ToString());
                }
                else
                {
                    problem = problem.Replace(operation, Calculate(operation).ToString());
                }
            }

            if (part2)
            {
                return CalculatePart2(problem);
            }
            else
            {
                return Calculate(problem);
            }

        }


        /// <summary>
        /// Given a string, returns the operation contained
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <returns>Result as string</returns>
        static Int64 Calculate(string operation)
        {

            Int64 result = 0;
            string sign = String.Empty;

            foreach (string s in operation.Replace("(", String.Empty)
                                      .Replace(")", String.Empty).Split(" "))
            {
                if (Int64.TryParse(s, out Int64 number))
                {
                    if (!sign.Equals(String.Empty))
                    {
                        if (sign.Equals("+"))
                        {
                            result += number;
                        }
                        else
                        {
                            result *= number;
                        }
                    }
                    else
                    {
                        result = number;
                    }
                }
                else
                {
                    sign = s;
                }
            }

            return result;

        }

        /// <summary>
        /// Given a string, returns the operation contained
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <returns>Result as string</returns>
        static Int64 CalculatePart2(string operation)
        {

            operation = operation.Replace("(", String.Empty)
                                 .Replace(")", String.Empty);

            // First additions shall be done
            while (operation.IndexOf('+') >= 0)
            {

                string[] parts = operation.Split(" ");

                int i = 0;

                while (!parts[i].Equals("+"))
                {
                    i++;
                }

                operation = String.Empty;

                for (int j = 0; j < i - 1; j++)
                {
                    operation += parts[j] + " ";
                }

                operation += String.Format("{0} ", Int64.Parse(parts[i - 1]) + Int64.Parse(parts[i + 1]));

                for (int j = i+2; j < parts.Length; j++)
                {
                    operation += parts[j] + " ";
                }

            }

            Int64 result = 1;

            foreach (string s in operation.Split('*'))
            {
                result *= Int64.Parse(s);
            }

            return result;

        }

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
        
            Console.WriteLine("First solution: {0}", (from p in Problems
                                                      select ProcessLine(p, false)).Sum());

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            Console.WriteLine("Second solution: {0}", (from p in Problems
                                                      select ProcessLine(p, true)).Sum());

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            Problems = new List<string>();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                Problems.Add(line);
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Main Program
        /// </summary>
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
