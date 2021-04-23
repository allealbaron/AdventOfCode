using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Task07
    {
        /// <summary>
        /// Steps
        /// </summary>
        private readonly Dictionary<string,Step> steps = new();

        /// <summary>
        /// Delay
        /// </summary>
        private readonly int delay;

        /// <summary>
        /// Workers
        /// </summary>
        private readonly List<Step> Workers = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public string FirstPart()
        {
            StringBuilder result = new();
            while (steps.Where(p => !p.Value.Executed).Any())
            {
                Step s = (from
                            c in steps
                         where
                             !c.Value.Executed && (
                             c.Value.PreviousSteps.Count == 0 ||
                             (!c.Value.PreviousSteps.Where(p => !p.Executed).Any()))
                         orderby c.Key
                         select c.Value).First<Step>();

                    s.Executed = true;
                    result.Append(s.Name);

            }

            return result.ToString();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            int iterations = 0;

            while (steps.Where(p => !p.Value.Executed).Any())
            {

                List<Step> stepsForLoad = (from
                            c in steps
                          where
                              !Workers.Contains(c.Value) &&
                              !c.Value.Executed && (
                              c.Value.PreviousSteps.Count == 0 ||
                              (!c.Value.PreviousSteps.Where(p => !p.Executed).Any()))
                          orderby c.Key
                          select c.Value).ToList<Step>();

                foreach (Step sw in stepsForLoad)
                {
                    if (!Workers.Contains(sw) && (Workers.Count < Workers.Capacity))
                    {
                        Workers.Add(sw);
                    }
                }

                for (int i = Workers.Count; i > 0; i--)
                {
                    Workers[i - 1].ExecutionTime--;

                    if (Workers[i - 1].ExecutionTime == 0)
                    {
                        Workers[i - 1].Executed = true;
                        Workers.RemoveAt(i - 1);
                    }
                }

                iterations++;
            }

            return iterations;

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            steps.Clear();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            List<string> lines = new();
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }

            sr.Close();
            fs.Close();

            Regex regexLine = new(@"^Step\s(?<Step1>([A-Z]{1}))\smust\sbe\sfinished\sbefore\sstep\s(?<Step2>([A-Z]{1}))\scan\sbegin.$");

            foreach (string l in lines)
            {

                Match resultMatch = regexLine.Match(l);

                string step1 = resultMatch.Groups["Step1"].Captures.First().Value;
                string step2 = resultMatch.Groups["Step2"].Captures.First().Value;

                if (!this.steps.ContainsKey(step1))
                {
                    steps.Add(step1, new Step(step1, delay));
                }

                if (!this.steps.ContainsKey(step2))
                {
                    steps.Add(step2, new Step(step2, delay));
                }

            }

            foreach (string l in lines)
            {

                Match resultMatch = regexLine.Match(l);

                string step1 = resultMatch.Groups["Step1"].Captures.First().Value;
                string step2 = resultMatch.Groups["Step2"].Captures.First().Value;

                steps[step2].PreviousSteps.Add(steps[step1]);

            }
        }
      
        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        /// <param name="delay">Delay</param>
        /// <param name="workers">Number of workers</param>
        public Task07(string fileName, int delay, int workers)
        {

            this.delay = delay;

            this.Workers = new (workers);

            LoadFile(fileName);

        }

        static void Main()
        {

            Task07 t = new("input.txt", 60, 5);

            Console.WriteLine("First Part: {0}", t.FirstPart());

            t = new("input.txt", 60, 5);

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
