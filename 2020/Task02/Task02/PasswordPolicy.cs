using System.Linq;

namespace AdventOfCode
{
    public class PasswordPolicy
    {
        /// <summary>
        /// Minimum value
        /// </summary>
        public int MinValue { get; set; }

        /// <summary>
        /// Maximum value
        /// </summary>
        public int MaxValue { get; set; }

        /// <summary>
        /// Character to check
        /// </summary>
        public char Character { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// Checks if the item is valid for the first part
        /// </summary>
        /// <returns>Returns value</returns>
        public bool IsValidFirstPart()
        {

            int times = this.PassWord.Where(t => t == this.Character).Count();

            return (this.MinValue <= times && times <= this.MaxValue);

        }

        /// <summary>
        /// Checks if the item is valid for the second part
        /// </summary>
        /// <returns>Returns value</returns>
        public bool IsValidSecondPart()
        {
            return (this.PassWord[this.MinValue-1] == this.Character ^
                    this.PassWord[this.MaxValue-1] == this.Character);
        }
    }
}
