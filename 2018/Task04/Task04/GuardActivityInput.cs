using System;

namespace AdventOfCode
{
    class GuardActivityInput: IComparable
    {

        /// <summary>
        /// Guard Activity Enum
        /// </summary>
        public enum GuardActivityEnum
        {
            BeginsShift,
            WakesUp,
            FallsAsleep
        }

        /// <summary>
        /// Time stamp
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// GuardId
        /// </summary>
        public int GuardId { get; set; }

        /// <summary>
        /// Activity
        /// </summary>
        public GuardActivityEnum Activity { get; set; }

        /// <summary>
        /// Compare method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            return TimeStamp.CompareTo(((GuardActivityInput)obj).TimeStamp);
        }
    }
}
