using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2022
{
    public class Task03
    {
     
        /// <summary>
        /// Rucksacks
        /// </summary>
        private readonly List<Tuple<List<char>, List<char>>> _rucksacks = new();

        public int GetCharValue(char input)
        {

            if (Char.IsLower(input))
            {
                return ((int)input - (97 - 1));
            }

            if (Char.IsUpper(input))
            {
                return ((int)input - (65 - 1) + 26);
            }

            return 0;

        }

        public char GetPriorityChar(Tuple<List<char>, List<char>> item)
        {

            return  (from x in item.Item1
                     from y in item.Item2
                     where x == y
                     select x).Distinct().FirstOrDefault();

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            return _rucksacks.Sum(t => GetCharValue(GetPriorityChar(t)));

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {
            var result = 0;

            const int GROUPNUMBER = 3;

            for (int i = 0; i < _rucksacks.Count / GROUPNUMBER; i++)
            {

                result += GetCharValue(
                            (
                                    from x in _rucksacks[(GROUPNUMBER * i)].Item1.Union(_rucksacks[(GROUPNUMBER * i)].Item2)
                                    from y in _rucksacks[(GROUPNUMBER * i) + 1].Item1.Union(_rucksacks[(GROUPNUMBER * i) + 1].Item2)
                                    from z in _rucksacks[(GROUPNUMBER * i) + 2].Item1.Union(_rucksacks[(GROUPNUMBER * i) + 2].Item2)
                                    where 
                                        x == y && x == z
                                    select x
                                  ).Distinct().FirstOrDefault());

            }

            return result;

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            _rucksacks.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            string line;
            

            while ((line = sr.ReadLine()) != null)
            {
                var item = new Tuple<List<char>, List<char>>(new List<char>(), new List<char>());

                for (int i = 0; i < (line.Length / 2); i++)
                {
                    item.Item1.Add(line[i]);
                    item.Item2.Add(line[i+ (line.Length / 2)]);
                }

                _rucksacks.Add(item);

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
