using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2022
{
    public class Task05
    {

        /// <summary>
        /// Stacks
        /// </summary>
        private readonly List<Stack<char>> _stacks = new();

        /// <summary>
        /// Movements
        /// </summary>
        private readonly List<Movement> _movements = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public string FirstPart()
        {

            foreach (var movement in _movements)
            {
                
                for (var i = 0; i < movement.Amount; i++)
                {
                    
                    if (_stacks[movement.Origin-1].Count > 0)
                    {
                        var temp = _stacks[movement.Origin-1].Pop();
                        _stacks[movement.Destination-1].Push(temp);
                    }

                }

            }

            var result = new StringBuilder();

            foreach (var s in _stacks)
            {
                
                if (s.Count > 0)
                {
                    result.Append(s.Peek());
                }

            }

            return result.ToString();

        }

        /// <summary>
        /// Second part
        /// </summary>
        public string SecondPart()
        {

            foreach (var movement in _movements)
            {
                var tempStack = new Stack<char>();

                for (var i = 0; i < movement.Amount; i++)
                {
                    
                    if (_stacks[movement.Origin - 1].Count > 0)
                    {
                        var temp = _stacks[movement.Origin - 1].Pop();
                        tempStack.Push(temp);
                    }

                }

                var maxCountTempStack = tempStack.Count;

                for (var i = 0; i < maxCountTempStack; i++)
                {
                    _stacks[movement.Destination - 1].Push(tempStack.Pop());
                }

            }

            var result = new StringBuilder();

            foreach (var s in _stacks)
            {
                if (s.Count > 0)
                {
                    result.Append(s.Peek());
                }
            }

            return result.ToString();

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            _stacks.Clear();
            _movements.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);

            var stacks = new List<string>();
            
            string line;

            line = sr.ReadLine();

            while (!string.IsNullOrWhiteSpace(line))
            {
                stacks.Add(line);
                line = sr.ReadLine();
            }

            foreach (var item in stacks.Last().Split(
                                " ", 
                                        StringSplitOptions.RemoveEmptyEntries))
            {
                _stacks.Add(new Stack<char>());
            }

            stacks.RemoveAt(stacks.Count-1);

            for (var i = stacks.Count-1; i>=0;i--)
            {

                for (var j = 0; j < stacks[i].Length; j += 4)
                {
                    if (stacks[i][j + 1] != ' ')
                    {
                        _stacks[j/4].Push(stacks[i][j + 1]);
                    }
                }
                
            }
            
            var regularExpression = new Regex(@"^move(\s+)(?<Amount>(\d+))(\s+)from(\s+)(?<Origin>(\d+))(\s+)to(\s+)(?<Destination>(\d+))$");

            while ((line = sr.ReadLine()) != null)
            {

                var match = regularExpression.Match(line);

                if (match.Success)
                {
                    _movements.Add(new ()
                    {
                        Amount = int.Parse(match.Groups["Amount"].Captures.First().Value),
                        Origin = int.Parse(match.Groups["Origin"].Captures.First().Value),
                        Destination = int.Parse(match.Groups["Destination"].Captures.First().Value)
                    });   
                }

            }
            
            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task05(string fileName)
        {

            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            var fileName = "TestInput.txt";
            Task05 t = new(fileName);

            Console.WriteLine("First Part: {0}", t.FirstPart());

            t = new(fileName);

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
