using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Step
    {
        /// <summary>
        /// Characters
        /// </summary>
        private readonly static List<char> characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList<char>();

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates if the step has been executed
        /// </summary>
        public bool Executed { get; set; }

        /// <summary>
        /// List of previous steps needed to execute
        /// </summary>
        public List<Step> PreviousSteps { get; set; }

        /// <summary>
        /// Execution Time
        /// </summary>
        public int ExecutionTime { get; set; }

        /// <summary>
        /// Class builder
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="delay">Delay</param>
        public Step(string name, int delay)
        {

            this.Name = name;
            this.Executed = false;
            this.PreviousSteps = new();
            this.ExecutionTime = 1 + delay + characters.IndexOf(name[0]);

        }

    }
}
