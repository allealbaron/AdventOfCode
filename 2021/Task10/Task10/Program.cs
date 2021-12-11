using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task10
    {

        /// <summary>
        /// Chunks
        /// </summary>
        private readonly List<List<char>> chunks = new();

        /// <summary>
        /// Stacks
        /// </summary>
        private readonly List<Stack<char>> stacks = new();

        /// <summary>
        /// Char couples
        /// </summary>
        private static readonly Dictionary<char, char> couples = new();

        /// <summary>
        /// Char scores (when a chunk is incorrect)
        /// </summary>
        private static readonly Dictionary<char, long> charIncorrectScores = new();

        /// <summary>
        /// Char scores (when a chunk is incomplete)
        /// </summary>
        private static readonly Dictionary<char, long> charIncompleteScores = new();

        /// <summary>
        /// Calculates chunk score
        /// </summary>
        /// <param name="chunk">Chunk</param>
        /// <returns>Score. 0 if it is not corrupted.</returns>
        private long CalculateChunkScore(List<char> chunk)
        {
            Stack<char> stack = new();

            foreach (char c in chunk)
            {
                if (couples.Values.Contains(c))
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Pop() != couples[c])
                    {
                        return charIncorrectScores[c];
                    }
                }
            }

            stacks.Add(stack);

            return 0;

        }

        /// <summary>
        /// Calculates incomplete score
        /// </summary>
        /// <param name="stack">Stack</param>
        /// <returns>Incomplete score.</returns>
        private static long CalculateIncompleteScore(Stack<char> stack)
        {

            List<char> tempResult = new();

            long result = 0;

            while (stack.Count != 0)
            {
                char tempChar = stack.Pop();
                result = (5 * result) + charIncompleteScores[couples.FirstOrDefault(c => c.Value == tempChar).Key];
            }

            return result;

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public long FirstPart()
        {

            return (from c in chunks select CalculateChunkScore(c)).Sum();

        }

        /// <summary>
        /// Second part
        /// </summary>
        public long SecondPart()
        {
            _ = FirstPart();

            return (from s in stacks
                    select CalculateIncompleteScore(s))
                    .OrderBy(t=>t)
                    .Select((item, index) => (item, index))
                    .FirstOrDefault(t=> t.index == (int)(stacks.Count / 2)).item;
                                            
        }

        /// <summary>
        /// Fills couples
        /// </summary>
        private static void FillCouples()
        {
            couples.Add(']', '[');
            couples.Add('}', '{');
            couples.Add(')', '(');
            couples.Add('>', '<');
        }

        /// <summary>
        /// Fills char incorrect scores
        /// </summary>
        private static void FillCharIncorrectScores()
        {
            charIncorrectScores.Add(')', 3);
            charIncorrectScores.Add(']', 57);
            charIncorrectScores.Add('}', 1197);
            charIncorrectScores.Add('>', 25137);
        }

        /// <summary>
        /// Fills char incomplete scores
        /// </summary>
        private static void FillCharIncompleteScores()
        {
            charIncompleteScores.Add(')', 1);
            charIncompleteScores.Add(']', 2);
            charIncompleteScores.Add('}', 3);
            charIncompleteScores.Add('>', 4);
        }


        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            chunks.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                chunks.Add(line.ToCharArray().ToList<char>());
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// static class builder
        /// </summary>
        static Task10()
        {

            FillCouples();

            FillCharIncorrectScores();

            FillCharIncompleteScores();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task10(string fileName)
        {
            
            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task10 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
