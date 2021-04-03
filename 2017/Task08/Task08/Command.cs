using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Command
    {
        /// <summary>
        /// Command Order
        /// </summary>
        public enum CommandOrderEnum
        { 
            inc,
            dec
        }

        /// <summary>
        /// Condition (<, <=, >, >=, ==, !=)
        /// </summary>
        public enum ConditionEnum
        { 
            greater,
            greaterOrEqual,
            less,
            lessOrEqual,
            equal,
            notEqual
        }

        /// <summary>
        /// Variable to modify in the command
        /// </summary>
        public string Variable { get; set; }

        /// <summary>
        /// Command Order
        /// </summary>
        public CommandOrderEnum CommandOrder { get; set; }

        /// <summary>
        /// Command Value
        /// </summary>
        public int CommandValue { get; set; }

        /// <summary>
        /// Condition Variable
        /// </summary>
        public string ConditionVariable { get; set; }

        /// <summary>
        /// Condition
        /// </summary>
        public ConditionEnum Condition { get; set; }

        /// <summary>
        /// Condition value
        /// </summary>
        public int ConditionValue { get; set; }

    }
}
