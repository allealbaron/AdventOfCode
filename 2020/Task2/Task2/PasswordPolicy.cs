using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public class PasswordPolicy
    {
        /// <summary>
        /// Minimum value
        /// </summary>
        public int MinValue;

        /// <summary>
        /// Maximum value
        /// </summary>
        public int MaxValue;

        /// <summary>
        /// Character to check
        /// </summary>
        public char Character;

        /// <summary>
        /// Password
        /// </summary>
        public string PassWord;

        /// <summary>
        /// Checks if the item is
        /// </summary>
        /// <param name="input">String to check</param>
        /// <returns>Returns value</returns>
        public bool IsValidFirstPart()
        {

            int times = this.PassWord.Where(t => t == this.Character).Count();

            return (this.MinValue <= times && times <= this.MaxValue);

        }

        public bool IsValidSecondPart()
        {
            return (this.PassWord[this.MinValue-1] == this.Character ^
                    this.PassWord[this.MaxValue-1] == this.Character);
        }
    }
}
