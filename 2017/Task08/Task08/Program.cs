using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Task08
    {
        /// <summary>
        /// Input
        /// </summary>
        private readonly List<Command> input = new();

        /// <summary>
        /// Variables
        /// </summary>
        private readonly Dictionary<string, int> variables = new();

        private int maxValue;

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

            Regex regexLine = new (@"(?<Variable>[A-Z-a-z\S]+)(?<FirstSpace>\s)(?<CommandOrder>(inc|dec))" +
                                        @"(?<SecondSpace>\s)(?<CommandValue>[\-]?[0-9]+)" +
                                        @"(?<if>(\sif\s))(?<VariableCondition>[A-Z-a-z\S]+)(?<ThirdSpace>\s)" +
                                        @"(?<Condition>(<|<=|>|>=|==|!=)\s)(?<ConditionValue>[\-]?[0-9]+)");

            while ((line = sr.ReadLine()) != null)
            {
                Match resultMatch = regexLine.Match(line);

                _ = Enum.TryParse(resultMatch.Groups["CommandOrder"].Captures.First().Value, out Command.CommandOrderEnum command);

                Command.ConditionEnum condition = Command.ConditionEnum.equal;

                switch (resultMatch.Groups["Condition"].Captures.First().Value.Trim())
                {
                    case ">":
                        condition = Command.ConditionEnum.greater;
                        break;
                    case ">=":
                        condition = Command.ConditionEnum.greaterOrEqual;
                        break;
                    case "<":
                        condition = Command.ConditionEnum.less;
                        break;
                    case "<=":
                        condition = Command.ConditionEnum.lessOrEqual;
                        break;
                    case "==":
                        condition = Command.ConditionEnum.equal;
                        break;
                    case "!=":
                        condition = Command.ConditionEnum.notEqual;
                        break;
                }

                input.Add(new Command() { 
                    Variable = resultMatch.Groups["Variable"].Captures.First().Value.Trim(),
                    CommandOrder = command,
                    CommandValue = Int32.Parse(resultMatch.Groups["CommandValue"].Captures.First().Value.Trim()),
                    ConditionVariable = resultMatch.Groups["VariableCondition"].Captures.First().Value.Trim(),
                    Condition = condition,
                    ConditionValue = Int32.Parse(resultMatch.Groups["ConditionValue"].Captures.First().Value.Trim())
                });

                if (!variables.Keys.Contains(input.Last().Variable))
                {
                    variables.Add(input.Last().Variable, 0);
                }

                if (!variables.Keys.Contains(input.Last().ConditionVariable))
                {
                    variables.Add(input.Last().ConditionVariable, 0);
                }

            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task08(string fileName)
        {
            LoadFile(fileName);
        }

        /// <summary>
        /// Execute commands
        /// </summary>
        private void ExecuteCommands()
        {
            maxValue = 0;

            foreach (Command c in input)
            {
                bool evaluation = true;

                switch (c.Condition)
                {
                    case Command.ConditionEnum.greater:
                        evaluation = (variables[c.ConditionVariable] > c.ConditionValue);
                        break;
                    case Command.ConditionEnum.greaterOrEqual:
                        evaluation = (variables[c.ConditionVariable] >= c.ConditionValue);
                        break;
                    case Command.ConditionEnum.less:
                        evaluation = (variables[c.ConditionVariable] < c.ConditionValue);
                        break;
                    case Command.ConditionEnum.lessOrEqual:
                        evaluation = (variables[c.ConditionVariable] <= c.ConditionValue);
                        break;
                    case Command.ConditionEnum.equal:
                        evaluation = (variables[c.ConditionVariable] == c.ConditionValue);
                        break;
                    case Command.ConditionEnum.notEqual:
                        evaluation = (variables[c.ConditionVariable] != c.ConditionValue);
                        break;
                }

                if (evaluation)
                {
                    if (c.CommandOrder == Command.CommandOrderEnum.inc)
                    {
                        variables[c.Variable] += c.CommandValue;
                    }
                    else
                    {
                        variables[c.Variable] -= c.CommandValue;
                    }

                    if (variables[c.Variable] > maxValue)
                    {
                        maxValue = variables[c.Variable];
                    }

                }

            }
        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            ExecuteCommands();

            return variables.Values.Max();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            ExecuteCommands();

            return maxValue;

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task08 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            t = new("input.txt");

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}

