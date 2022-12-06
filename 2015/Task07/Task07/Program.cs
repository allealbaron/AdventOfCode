using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Year2015.Operations;

namespace AdventOfCode.Year2015
{
    public class Task07
    {

        private const string AND_TOKEN = " AND ";
        private const string OR_TOKEN = " OR ";
        private const string LSHIFT_TOKEN = " LSHIFT ";
        private const string RSHIFT_TOKEN = " RSHIFT ";
        private const string NOT_TOKEN = "NOT ";

        /// <summary>
        /// pairs
        /// </summary>
        private readonly IDictionary<string, UInt16> _memoryPositions = new Dictionary<string, UInt16>();

        /// <summary>
        /// Operations
        /// </summary>
        private readonly IList<Operation> _operations = new List<Operation>();

        private void ExecuteOperations()
        {

            while (_operations.Any(t => !t.Processed))
            {

                foreach (var op in _operations.Where(
                         t => !t.Processed 
                              && !t.Values[0].HasValue 
                              && UInt16.TryParse(t.Inputs[0], out UInt16 tempResult)))
                {
                    op.Values[0] = UInt16.Parse(op.Inputs[0]);
                }

                foreach (var op in _operations.Where(
                             t => !t.Processed 
                                  && t.Values.Count>1 
                                               && !t.Values[1].HasValue 
                                               && UInt16.TryParse(t.Inputs[1], out UInt16 tempResult)))
                {
                    op.Values[1] = UInt16.Parse(op.Inputs[1]);
                }

                foreach (var op in _operations.Where(t => !t.Processed && t.Values.All(v => v.HasValue)))
                {

                    op.Processed = true;
                    _memoryPositions[op.Target] = op.GetValue();

                    foreach (Operation op2 in _operations.Where(t => !t.Processed 
                                                                     && t.Inputs[0] == op.Target))
                    {
                        op2.Inputs[0] = _memoryPositions[op.Target].ToString();
                    }

                    foreach (Operation op2 in _operations.Where(t => !t.Processed 
                                                                     && t.Inputs.Count > 1 
                                                                     && t.Inputs[1] == op.Target))
                    {
                        op2.Inputs[1] = _memoryPositions[op.Target].ToString();
                    }

                }

            }

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            ExecuteOperations();

            if (_memoryPositions.ContainsKey("a"))
            {
                return (int)_memoryPositions["a"];
            }

            return 0;

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart(int startValue)
        {
            
            if (_memoryPositions.ContainsKey("b"))
            {
                _operations.Where(o => o.Target == "b").Single().Inputs[0] = startValue.ToString();
            }

            ExecuteOperations();

            if (_memoryPositions.ContainsKey("a"))
            {
                return (int)_memoryPositions["a"];
            }

            return 0;
            
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            
            _memoryPositions.Clear();
            _operations.Clear();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            string line;
            

            while ((line = sr.ReadLine()) != null)
            {

                var firstSplit = line.Split(" -> ");

                var operation = firstSplit[0];
                var target = firstSplit[1];

                if (!_memoryPositions.ContainsKey(target))
                {
                    _memoryPositions.Add(target, 0);
                }

                switch (operation)
                {
                    case var andOperation when operation.Contains(AND_TOKEN):
                    {
                        var secondSplit = operation.Split(AND_TOKEN);
                        _operations.Add(new AndOperation() 
                        { 
                            Target = target, 
                            Values = { null, null }, 
                            Inputs = {secondSplit[0], secondSplit[1]}
                        });
                        break;
                    }
                    case var orOperation when operation.Contains(OR_TOKEN):
                    {
                        var secondSplit = operation.Split(OR_TOKEN);
                        _operations.Add(new OrOperation()
                        {
                            Target = target,
                            Values = { null, null },
                            Inputs = { secondSplit[0], secondSplit[1] }
                        });
                        break;
                    }
                    case var lShiftOperation when operation.Contains(LSHIFT_TOKEN):
                    {
                        var secondSplit = operation.Split(LSHIFT_TOKEN);
                        _operations.Add(new LShiftOperation()
                        {
                            Target = target,
                            Values = { null, null },
                            Inputs = { secondSplit[0], secondSplit[1]}
                        });
                        break;
                    }
                    case var rShiftOperation when operation.Contains(RSHIFT_TOKEN):
                    {
                        var secondSplit = operation.Split(RSHIFT_TOKEN);
                        _operations.Add(new RShiftOperation()
                        {
                            Target = target,
                            Values = { null, null },
                            Inputs = { secondSplit[0], secondSplit[1] }
                        });
                        break;
                    }
                    case var rNotOperation when operation.StartsWith(NOT_TOKEN):
                    {
                        var secondSplit = operation.Split(NOT_TOKEN);
                        _operations.Add(new NotOperation()
                        {
                            Target = target,
                            Values = { null },
                            Inputs = { secondSplit[1] }
                        });
                        break;
                    }
                    default:
                    {
                        _operations.Add(new AssignOperation()
                        {
                            Target = target,
                            Values = { null },
                            Inputs = {operation}
                        });
                        break;
                    }
                }

            }

            sr.Close();
            fs.Close();

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
        /// Main Thread
        /// </summary>
        static void Main()
        {

            var fileName = "input.txt";

            Task07 t = new(fileName);

            var firstPart = t.FirstPart();

            Console.WriteLine("First Part: {0}", firstPart);

            t = new (fileName);

            Console.WriteLine("Second Part: {0}", t.SecondPart(firstPart));

        }

    }
}
