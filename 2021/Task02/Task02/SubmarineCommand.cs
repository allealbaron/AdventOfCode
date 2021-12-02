using System;

namespace AdventOfCode.Year2021
{
    class SubmarineCommand
    {

        /// <summary>
        /// CommandType
        /// </summary>
        public enum CommandType
        {
            up,
            down,
            forward
        }

        /// <summary>
        /// Command
        /// </summary>
        public CommandType Command { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public int Amount { get; set; }


        /// <summary>
        /// Class builder
        /// </summary>
        /// <param name="commandAsString">Command as a string</param>
        /// <param name="amount">Amount</param>
        public SubmarineCommand(string commandAsString, int amount) 
        {

            _ = Enum.TryParse(commandAsString, out CommandType tempCommand);

            this.Command = tempCommand;
            this.Amount = amount;

        }

    }
}
