using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task6
{
    class Program
    {

        /// <summary>
        /// Responses
        /// </summary>
        static List<GroupResponse> groupResponses = new List<GroupResponse>();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
           
            Console.WriteLine("First solution:");

            Console.WriteLine("Sum: {0}", groupResponses.Sum(p => p.Responses.Count));

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            Console.WriteLine("Second solution:");

            Console.WriteLine("Sum: {0}", groupResponses.Sum(p => p.AnsweredByEveryBody.Count));

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            
            groupResponses = new List<GroupResponse>();

            GroupResponse gr = new GroupResponse();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Equals(String.Empty))
                {
                    groupResponses.Add(gr);
                    gr = new GroupResponse();
                }
                else
                {
                    foreach (char c in line)
                    {
                        if (gr.Responses.ContainsKey(c))
                        {
                            gr.Responses[c]++;
                        }
                        else
                        {
                            gr.Responses.Add(c, 1);
                        }
                    }
                    gr.Members++;
                }
            }

            groupResponses.Add(gr);

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
