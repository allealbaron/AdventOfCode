using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Task04
    {
        /// <summary>
        /// Min value
        /// </summary>
        public const int MIN_VALUE = 178416;

        /// <summary>
        /// Max value
        /// </summary>
        public const int MAX_VALUE = 676461;

        /// <summary>
        /// Input
        /// </summary>
        private readonly List<int> solutions = new();

        /// <summary>
        /// Returns if the number constains at least two
        /// adjacent numbers
        /// </summary>
        /// <param name="number">number to evaluate</param>
        /// <returns>True if contains at least two adjacent numbers</returns>
        public static bool TwoAdjacent(int number)
        {

            bool result = false;

            string numberAsString = number.ToString();

            for (int i = 0; i < numberAsString.Length-1; i++)
            {
                if (numberAsString[i].Equals(numberAsString[i + 1]))
                {
                    return true;
                }
            }

            return result;

        }

        /// <summary>
        /// Returns if the number has increasing numbers
        /// </summary>
        /// <param name="number">number to evaluate</param>
        /// <returns>True if every number is increasing</returns>
        public static bool IncreasingDigits(int number)
        {
            bool result = true;

            string numberAsString = number.ToString();

            for (int i = 0; i < numberAsString.Length - 1; i++)
            {
                if (Int32.Parse(numberAsString[i].ToString()) > Int32.Parse(numberAsString[i+1].ToString()))
                {
                    return false;
                }
            }

            return result;

        }

        /// <summary>
        /// Returns if the number constains at least two
        /// adjacent numbers
        /// </summary>
        /// <param name="number">number to evaluate</param>
        /// <returns>True if contains at least two adjacent numbers</returns>
        public static bool TwoAdjacentSecondPart(int number)
        {

            bool result = false;

            string numberAsString = number.ToString();

            int i = 0;
            int repetitions = 1;

            while (i < numberAsString.Length-1)
            {
                repetitions = 1;

                while (i < numberAsString.Length - 1 && 
                    numberAsString[i].Equals(numberAsString[i + 1]))
                {
                    i++;
                    repetitions++;
                }

                if (repetitions == 2)
                {
                    return true;
                }

                i++;

            }

            return result;

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            solutions.Clear();

            for (int i = MIN_VALUE; i < MAX_VALUE; i++)
            {
                if (TwoAdjacent(i) && IncreasingDigits(i))
                {
                    solutions.Add(i);
                }
            }

            return solutions.Count;

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            solutions.Clear();

            for (int i = MIN_VALUE; i < MAX_VALUE; i++)
            {
                if (TwoAdjacent(i) && IncreasingDigits(i) 
                    && TwoAdjacentSecondPart(i))
                {
                    solutions.Add(i);
                }
            }

            return solutions.Count;

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task04 t = new();

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}

