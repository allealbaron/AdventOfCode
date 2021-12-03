using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task03
    {

        /// <summary>
        /// Diagnostics
        /// </summary>
        private readonly List<String> diagnostics = new();

        /// <summary>
        /// Given a <paramref name="input"/>, gets the most and less common item at position <paramref name="index"/>
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="index">Index</param>
        /// <returns>Most and Less common items</returns>
        private static (char min, char max) GetMostLestCommon(List<string> input, int index)
        {
            (char min, char max) result;

            int count0 = 0;
            int count1 = 0;

            foreach (string item in input)
            {
                if (item[index] == '0')
                {
                    count0++;
                }
                else
                {
                    count1++;
                }
                if ((count0 > input.Count / 2) || (count1 > input.Count / 2))
                {
                    break;
                }
            }


            if (count0 > count1)
            {
                result = ('0', '1');
            }
            else
            {
                result = ('1', '0');
            }

            return result;

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {
            
            StringBuilder gammaRate = new();
            StringBuilder epsilonRate = new();

            for (int i = 0; i < diagnostics[0].Length; i++)
            {

                (char gamma, char epsilon) = GetMostLestCommon(diagnostics, i);

                gammaRate.Append(gamma);
                epsilonRate.Append(epsilon);

            }

            return Convert.ToInt32(gammaRate.ToString(), 2) * Convert.ToInt32(epsilonRate.ToString(), 2);

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            List<string> oxygenList = diagnostics.ToList();
            List<string> co2List = diagnostics.ToList();

            int i = 0;

            while (oxygenList.Count > 1)
            {
                (char oxygen, char co2) = GetMostLestCommon(oxygenList, i);

                if (oxygen.Equals(co2))
                {
                    oxygenList.RemoveAll(t => t[i] == '0');
                }
                else
                {
                    oxygenList.RemoveAll(t => t[i] == co2);
                }

                i++;

            }

            i = 0;

            while (co2List.Count > 1)
            { 

                (char oxygen, char co2) = GetMostLestCommon(co2List, i);

                if (oxygen.Equals(co2))
                {
                    oxygenList.RemoveAll(t => t[i] == '1');
                }
                else
                {

                    co2List.RemoveAll(t => t[i] == oxygen);
                }

                i++;

            }

            return Convert.ToInt32(oxygenList.FirstOrDefault(), 2) * Convert.ToInt32(co2List.FirstOrDefault(), 2);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            diagnostics.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                diagnostics.Add(line);
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task03(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task03 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
