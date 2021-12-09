using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task09
    {

        /// <summary>
        /// Points
        /// </summary>
        private readonly List<CavePoint> points = new();      

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            for (int i = 1; i < points.Select(t=> t.X).Max(); i++)
            {
                for (int j = 1; j < points.Select(t => t.Y).Max(); j++)
                {
                    CavePoint pivot = points.FirstOrDefault(t => t.X == i && t.Y == j);

                    if (pivot.Value < points.FirstOrDefault(t => t.X == i && t.Y == j-1).Value &&
                        pivot.Value < points.FirstOrDefault(t => t.X == i && t.Y == j + 1).Value &&
                        pivot.Value < points.FirstOrDefault(t => t.X == i - 1 && t.Y == j).Value &&
                        pivot.Value < points.FirstOrDefault(t => t.X == i + 1 && t.Y == j).Value 
                        )
                    {
                        pivot.IsRiskLevel = true;
                    }

                }
            }

            return (from c in points where c.IsRiskLevel select c.Value + 1).Sum();

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {
            _ = FirstPart();

            int basinNumber = 1;

            foreach (CavePoint r in points.Where(t => t.IsRiskLevel))
            {
                bool oneFound= true;

                r.BasinValue = basinNumber;

                while (oneFound)
                {
                    oneFound = false;

                    foreach (CavePoint c in points.Where(t => t.BasinValue == basinNumber && !t.BasinProcessed).ToList())
                    {
                        c.BasinProcessed = true;
                        
                        if (points.Any(t => t.X == c.X - 1 && t.Y == c.Y && t.BasinValue == 0 && t.Value<9))
                        {
                            oneFound = true;
                            points.FirstOrDefault(t => t.X == c.X - 1 && t.Y == c.Y).BasinValue = basinNumber;
                        }

                        if (points.Any(t => t.X == c.X + 1 && t.Y == c.Y && t.BasinValue == 0 && t.Value < 9))
                        {
                            oneFound = true;
                            points.FirstOrDefault(t => t.X == c.X + 1 && t.Y == c.Y).BasinValue = basinNumber;
                        }

                        if (points.Any(t => t.X == c.X && t.Y == c.Y - 1 && t.BasinValue == 0 && t.Value < 9))
                        {
                            oneFound = true;
                            points.FirstOrDefault(t => t.X == c.X && t.Y == c.Y - 1).BasinValue = basinNumber;
                        }

                        if (points.Any(t => t.X == c.X && t.Y == c.Y + 1 && t.BasinValue == 0 && t.Value < 9))
                        {
                            oneFound = true;
                            points.FirstOrDefault(t => t.X == c.X && t.Y == c.Y + 1).BasinValue = basinNumber;
                        }

                    }
                }

                basinNumber++;
            }

            return (from p in points
                    where p.BasinValue != 0
                    group p by p.BasinValue into g
                    select new
                    {
                        cnt = g.Count()
                    }
                     ).OrderByDescending(p => p.cnt)
                     .Take(3)
                     .Select(t => t.cnt).Aggregate((total, next) => total * next);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            points.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            int i = 1;

            while ((line = sr.ReadLine()) != null)
            {

                points.Add(new(i,0, 9));

                for (int j = 0; j < line.Length; j++)
                {
                    points.Add(new(i, j+1, Int32.Parse(line[j].ToString())));
                }

                points.Add(new(i, line.Length+1, 9));

                i++;

            }

            for (int j = 0; j < (points.Select(t => t.Y).Max()); j++)
            {
                points.Add(new(0,j,9));
                points.Add(new(i,j,9));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task09(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task09 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
