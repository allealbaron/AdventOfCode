using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task07
    {
        /// <summary>
        /// Input
        /// </summary>
        private readonly Dictionary<string,TreeProgram> input = new();

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            List<string> lines = new ();

            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }

            sr.Close();
            fs.Close();

            foreach (string l in lines)
            {
                
                string[] parts;

                if (l.Contains("->"))
                {
                    string[] partsArrow = l.Split("->");

                    parts = partsArrow[0].Trim().Split(' ');

                }
                else
                {
                    parts = l.Split(' ');
                }

                input.Add(parts[0].Trim(), 
                        new() 
                        { 
                            Name= parts[0].Trim(),
                            Weight = int.Parse(parts[1].Replace("(", String.Empty).Replace(")",String.Empty)) 
                        });

            }
            
            foreach (string l in lines.Where(p => p.Contains("->")).ToList<string>())
            {
                string[] partsArrow = l.Split("->");

                string[] parts = partsArrow[0].Trim().Split(' ');

                foreach (string s in partsArrow[1].Trim().Split(", "))
                {
                    input[parts[0].Trim()].Children.Add(input[s]);
                }

            }

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task07(string fileName)
        {
            LoadFile(fileName);
        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public string FirstPart()
        {
            List<TreeProgram> result = (from i in input where i.Value.Children.Count > 0 select i.Value).ToList<TreeProgram>();

            string solution = String.Empty;

            while (result.Count > 0)
            {

                solution = result.First().Name;

                result = (from i1 in result
                         from i2 in result
                         where i2.Children.Contains(i1)
                         select i2).Distinct().ToList<TreeProgram>();

            }

            return solution;

        }

        /// <summary>
        /// Recursive function, calculates total weight
        /// </summary>
        /// <param name="treeprogram"></param>
        /// <returns>Total weight</returns>
        private int CalculateTotalWeight(TreeProgram treeprogram)
        {
            int result = treeprogram.Weight;

            foreach (TreeProgram child in treeprogram.Children)
            {
                result += CalculateTotalWeight(child);
            }

            return result;

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            List<string> parentName = new();

            parentName.Add(FirstPart());

            var weightsGrouped = input[parentName.Last()].Children.GroupBy(t => CalculateTotalWeight(t)).Select(group => new
            {
                Weight = group.Key,
                Count = group.Count()
            });

            while (weightsGrouped.ToList().Count > 1)
            {
                int differentWeight = (from i in weightsGrouped
                                       from t in input
                                        where i.Count == 1 && i.Weight == CalculateTotalWeight(t.Value)
                                        select i.Weight).First();

                parentName.Add((from i in input
                                from j in input
                         where differentWeight == CalculateTotalWeight(i.Value) && j.Value.Children.Contains(i.Value) 
                         && j.Key == parentName.Last()
                         select i.Key).First());

                weightsGrouped = input[parentName.Last()].Children.GroupBy(t => CalculateTotalWeight(t)).Select(group => new
                {
                    Weight = group.Key,
                    Count = group.Count()
                });

            }

            weightsGrouped = input[parentName[^2]].Children.GroupBy(t => CalculateTotalWeight(t)).Select(group => new
            {
                Weight = group.Key,
                Count = group.Count()
            });

            return (from t1 in weightsGrouped
                    from t2 in weightsGrouped
                    from t3 in input
                    where t1.Count == 1 && t2.Count != 1
                    && CalculateTotalWeight(t3.Value) == t1.Weight
                    select (t3.Value.Weight + t2.Weight - t1.Weight)).First();

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task07 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}

