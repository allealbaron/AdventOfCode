using System;
using System.Collections.Generic;
using System.Text;

namespace Task8
{
    /// <summary>
    /// Command
    /// </summary>
    class CommandExecution
    {
        /// <summary>
        /// Command
        /// </summary>
        public enum Operation
        { 
            nop,
            acc,
            jmp
        }

        /// <summary>
        /// Operation
        /// </summary>
        public Operation Command;

        /// <summary>
        /// Movements
        /// </summary>
        public int Movements;

        /// <summary>
        /// Indicates if the command is executed
        /// </summary>
        public bool Executed = false;

        /// <summary>
        /// Gets Command's conjugate
        /// </summary>
        /// <returns>New command</returns>
        public CommandExecution.Operation GetConjugate()
        {
            switch (Command)
            {
                case CommandExecution.Operation.jmp:
                    return CommandExecution.Operation.nop;
                case CommandExecution.Operation.nop:
                    return CommandExecution.Operation.jmp;
                default:
                    return Command;
            }

        }


    }
}
