using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Task06
    {
        /// <summary>
        /// Input
        /// </summary>
        private List<int> input = new();

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

            line = sr.ReadLine();

            input = line.Split('\t').Select(p => Int32.Parse(p)).ToList<int>();

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
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            HashSet<string> permutations = new();

            int loops = 0;

            string listAsString = string.Join(",", input.Select(i => i.ToString()).ToArray());

            do
            {
                permutations.Add(listAsString);

                int index = input.Select((x, i) => new { value = x, index = i }).OrderBy(t => t.index).ToList()
                            .Where(p => p.value == input.Max()).First().index;

                int selectedValue = input[index];

                input[index] = 0;

                int pivot = (index + 1) % input.Count;

                while (selectedValue > 0)
                {
                    input[pivot]++;
                    pivot = (pivot + 1) % input.Count;
                    selectedValue--;
                }

                loops++;
                listAsString = string.Join(",", input.Select(i => i.ToString()).ToArray());

            }
            while (!permutations.Contains(listAsString));

            return loops;

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            List<string> permutations = new();

            int loops = 0;

            string listAsString = string.Join(",", input.Select(i => i.ToString()).ToArray());

            do
            {
                permutations.Add(listAsString);

                int index = input.Select((x, i) => new { value = x, index = i }).OrderBy(t => t.index).ToList()
                            .Where(p => p.value == input.Max()).First().index;

                int selectedValue = input[index];

                input[index] = 0;

                int pivot = (index + 1) % input.Count;

                while (selectedValue > 0)
                {
                    input[pivot]++;
                    pivot = (pivot + 1) % input.Count;
                    selectedValue--;
                }

                loops++;
                listAsString = string.Join(",", input.Select(i => i.ToString()).ToArray());

            }
            while (!permutations.Contains(listAsString));

            return  (loops - permutations.Select((x, i) => new { value = x, index = i }).OrderBy(t => t.index).ToList()
                            .Where(p => p.value == listAsString).First().index);

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

