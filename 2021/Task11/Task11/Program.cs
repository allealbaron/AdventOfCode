using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task11
    {

        /// <summary>
        /// Octopuses
        /// </summary>
        private readonly List<Octopus> octopuses = new();

        /// <summary>
        /// Increment all octopuses (+1)
        /// </summary>
        private void IncrementAll()
        {
            foreach (Octopus o in octopuses)
            {
                o.Increment();
            }
        }

        /// <summary>
        /// DeFlash octopus in the frame
        /// </summary>
        private void DeFlashFrameOctopus()
        {
            foreach (Octopus o in octopuses.Where
                            (t => t.X == 0 || 
                            t.Y == 0 || 
                            t.X== octopuses.Select(x=>x.X).Max() ||
                            t.Y == octopuses.Select(y => y.Y).Max()))
            {
                o.DeFlash();
            }
        }

        /// <summary>
        /// Deflash all octopus previously flashed
        /// and the octopus in the frame (X or Y equals 0)
        /// </summary>
        private void DeFlashAll()
        {

            foreach (Octopus o in octopuses.Where(t=> t.Flashed))
            {
                o.DeFlash();
            }

        }

        private long Iterate()
        {
            long result = 0;
            IncrementAll();

            while (octopuses.Any(t => !t.Flashed && t.Value > 9))
            {

                foreach (Octopus o in octopuses.Where(t => !t.Flashed && t.Value > 9))
                {

                    for (int i = o.X - 1; i <=o.X + 1 && i< octopuses.Select(x => x.X).Max(); i++)
                    {

                        for (int j = o.Y - 1; j <= o.Y + 1 && j < octopuses.Select(y => y.Y).Max(); j++)
                        {

                            octopuses.FirstOrDefault(t => t.X == i && t.Y == j).Increment();

                        }
                    
                    }

                    o.Flash();
                    DeFlashFrameOctopus();
                }
                
            }

            result = octopuses.Where(t => t.Flashed).Count();

            DeFlashAll();

            return result;

        }

        /// <summary>
        /// Execute steps
        /// </summary>
        /// <param name="steps">Number of steps</param>
        /// <returns>Sum of flashed octopus during the iteration</returns>
        public long ExecuteSteps(int steps)
        {
            long result = 0;
            
            for (int i = 0; i < steps; i++)
            {
                result += Iterate();
            }
            
            return result;

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public long FirstPart()
        {

            return ExecuteSteps(100);

        }

        /// <summary>
        /// Second part
        /// </summary>
        public long SecondPart()
        {
            int counter = 0;
            while (!octopuses.All(t => t.Value == 0))
            {
                _ = Iterate();
                counter++;
            }
            return counter;

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            octopuses.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            int i = 1;

            while ((line = sr.ReadLine()) != null)
            {
                octopuses.Add(new(i, 0, -1));
                int j = 1;

                foreach (int v in line.Select(p => Int32.Parse(p.ToString())))
                {
                    octopuses.Add(new (i,j,v));
                    j++;
                }

                octopuses.Add(new(i, j, -1));

                i++;
            }

            int maxValue = octopuses.Select(p => p.Y).Max();

            for (int j = 0; j <= maxValue; j++)
            {
                octopuses.Add(new(0, j, -1));
                octopuses.Add(new(maxValue, j, -1));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task11(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task11 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
