using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021
{
    /// <summary>
    /// Bingo Card
    /// </summary>
    public class BingoCard
    {
        /// <summary>
        /// Bingo Card
        /// </summary>
        public List<List<BingoNumber>> Card { get; set; }

        /// <summary>
        /// Class Builder
        /// </summary>
        public BingoCard()
        {
            Card = new List<List<BingoNumber>>();
        }

        /// <summary>
        /// Given a number, it checks it
        /// </summary>
        /// <param name="number">Number to check</param>
        public void CheckNumber(int number)
        {

            foreach (BingoNumber bingoNumber in
                        (from line in Card from bn in line where bn.Value == number select bn))
            {
                bingoNumber.Checked = true;
            }

        }

        /// <summary>
        /// Checks if the card has completed a line
        /// </summary>
        /// <returns>True if at least a line is completed</returns>
        public bool HasLine()
        {

            if (Card.Any(line => line.All(number => number.Checked)))
            {
                // There is a match in a horizontal line
                return true;
            }
            else
            {

                for (int i = 0; i < Card.Count; i++)
                {
                    if (Card.All(line => line[i].Checked))
                    {
                        return true;
                    }
                }

            }

            return false;

        }

        /// <summary>
        /// Returns the sum of all unmarked numbers
        /// </summary>
        /// <returns>Sum of all unmarked numbers</returns>
        public int GetCardScore()
        {
            return (from line in Card
                    from number in line
                    where (!number.Checked)
                    select number.Value
                    ).Sum();
        }

    }
}