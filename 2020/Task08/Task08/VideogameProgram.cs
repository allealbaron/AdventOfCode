using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task08
{
    class VideogameProgram
    {
        /// <summary>
        /// Program
        /// </summary>
        public List<CommandExecution> Program;

        /// <summary>
        /// Accumulator
        /// </summary>
        public int Accumulator;

        /// <summary>
        /// Pointer
        /// </summary>
        public int PC;

        /// <summary>
        /// Class Builder
        /// </summary>
        public VideogameProgram()
        {
            Program = new List<CommandExecution>();
            Accumulator = 0;
            PC = 0;
        }

        /// <summary>
        /// Executes program until it reaches an infinite loop
        /// </summary>
        /// <returns>PC</returns>
        public int ExecuteProgram()
        {
            
            while (!Program[PC].Executed && PC<Program.Count-1)
            {
                Program[PC].Executed = true;
                switch (Program[PC].Command)
                {
                    case CommandExecution.Operation.nop:

                        PC++;
                        break;

                    case CommandExecution.Operation.acc:

                        Accumulator += Program[PC].Movements;
                        PC++;
                        break;

                    case CommandExecution.Operation.jmp:
                        PC += Program[PC].Movements;
                        break;

                }
            }

            return Accumulator;
        }

        /// <summary>
        /// Executes program with debug
        /// </summary>
        /// <returns></returns>
        public int ExecuteWithDebug()
        {
            int j = 0;

            while (PC < Program.Count-1)
            {

                ResetProgram();

                while (PC < Program.Count && !Program[PC].Executed)
                {
                    Program[PC].Executed = true;

                    CommandExecution.Operation nextOperation = Program[PC].Command;

                    if (PC == j)
                    {
                        nextOperation = Program[PC].GetConjugate();
                    }

                    switch (nextOperation)
                    {
                        case CommandExecution.Operation.nop:

                            PC++;
                            break;

                        case CommandExecution.Operation.acc:

                            Accumulator += Program[PC].Movements;
                            PC++;
                            break;

                        case CommandExecution.Operation.jmp:
                            PC += Program[PC].Movements;
                            break;

                    }
                }

                j++;

            }

            return Accumulator;

        }

        /// <summary>
        /// Reset program
        /// </summary>
        private void ResetProgram()
        {
            Program.Select(c => { c.Executed = false; return c; }).ToList();
            Accumulator = 0;
            PC = 0;
        }

    }
}
