using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task06
    {

        /// <summary>
        /// Initial lifespan when a fish is born the first time
        /// </summary>
        private const int INITIAL_VALUE_FISH_FIRST_BORN = 8;

        /// <summary>
        /// Initial lifespan when a fish is born not the first time
        /// </summary>
        private const int INITIAL_VALUE_FISH_REBORN = 6;

        /// <summary>
        /// School of Lanternfish
        /// </summary>
        private readonly List<long> lanternfishSchool = new();

        /// <summary>
        /// Simulates the <see cref="lanternfishSchool"/> after <paramref name="days"/>
        /// </summary>
        /// <param name="days">Number of days</param>
        /// <returns>Number of lanternfishes after <paramref name="days"/></returns>
        public long SimulateDays(int days)
        {

            for (int i = 0; i < days; i++)
            {

                long dyingLanternfishes = lanternfishSchool[0];

                for (int j = 1; j <= INITIAL_VALUE_FISH_FIRST_BORN; j++)
                {
                    lanternfishSchool[j - 1] = lanternfishSchool[j];
                }

                lanternfishSchool[INITIAL_VALUE_FISH_REBORN] += dyingLanternfishes;
                lanternfishSchool[INITIAL_VALUE_FISH_FIRST_BORN] = dyingLanternfishes;

            }

            return lanternfishSchool.Sum();
        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public long FirstPart()
        {

            return SimulateDays(80);

        }

        /// <summary>
        /// Second part
        /// </summary>
        public long SecondPart()
        {

            return SimulateDays(256);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            for (int i = 0; i <= INITIAL_VALUE_FISH_FIRST_BORN; i++)
            {
                lanternfishSchool.Add(0);
            }
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                foreach (string str in line.Split(','))
                {
                    lanternfishSchool[Int32.Parse(str)]++;
                }
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task06(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task06 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            t = new("input.txt");

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
