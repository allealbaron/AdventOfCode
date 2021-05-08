using System;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    /// <summary>
    /// Class which represents passport information
    /// </summary>
    public class PassportInformation
    {
        /// <summary>
        /// Categories
        /// </summary>
        public enum Category
        {
            byr,
            iyr,
            eyr,
            hgt,
            hcl,
            ecl,
            pid,
            cid          
        }

        /// <summary>
        /// Eye colors
        /// </summary>
        public enum EyeColorEnum
        {
            amb, 
            blu, 
            brn, 
            gry, 
            grn, 
            hzl, 
            oth
        }

        /// <summary>
        /// Eye color
        /// </summary>
        private EyeColorEnum eyes;
        
        /// <summary>
        /// Birth Year
        /// </summary>
        public int BirthYear;

        /// <summary>
        /// Issue Year
        /// </summary>
        public int IssueYear;

        /// <summary>
        /// Expiration Year
        /// </summary>
        public int ExpirationYear;

        /// <summary>
        /// Height
        /// </summary>
        public string Height;

        /// <summary>
        /// Hair Color
        /// </summary>
        public string HairColor;

        /// <summary>
        /// Eye Color
        /// </summary>
        public string EyeColor;

        /// <summary>
        /// Passport Id
        /// </summary>
        public string PassportId;

        /// <summary>
        /// Country Id
        /// </summary>
        public string CountryId;

        /// <summary>
        /// Checks if the item is valid (first part)
        /// </summary>
        /// <returns>True if evertything is valid, False otherwise</returns>
        public bool IsValid()
        {
            return (
                this.BirthYear > 0 
                && this.ExpirationYear>0
                && !String.IsNullOrEmpty(this.EyeColor)
                && !String.IsNullOrEmpty(this.HairColor)
                && !String.IsNullOrEmpty(this.Height)
                && !String.IsNullOrEmpty(this.PassportId)
                && this.IssueYear>0 
           );
        }

        /// <summary>
        /// Checks if the item is valid (second part)
        /// </summary>
        /// <returns>True if evertything is valid, False otherwise</returns>
        public bool IsValidSecondPart()
        {
            return (
                this.IsValid()
                && ValidateNumber(this.BirthYear, 1920, 2002)
                && ValidateNumber(this.IssueYear, 2010, 2020)
                && ValidateNumber(this.ExpirationYear, 2020, 2030)
                && ValidateEyeColor()
                && ValidatePassportId()
                && ValidateHairColor()
                && ValidateHeight()
                );
        }

        /// <summary>
        /// Validates if a value is between another two
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns>True if the <paramref name="value"/> is between <paramref name="minValue"/> 
        /// and <paramref name="maxValue"/>
        /// </returns>
        private static bool ValidateNumber(int value, int minValue, int maxValue)
        {
            return (value >= minValue && value <= maxValue);
        }

        /// <summary>
        /// Validates eye color
        /// </summary>
        /// <returns>True if eye color is valid</returns>
        private bool ValidateEyeColor()
        {
            return Enum.TryParse(this.EyeColor, out this.eyes);
        }

        /// <summary>
        /// Validates password id
        /// </summary>
        /// <returns>True if passport id is a nine digit number</returns>
        private bool ValidatePassportId()
        {
            Regex regexPassportId = new(@"^([0-9]{9})$");

            return regexPassportId.IsMatch(this.PassportId);

        }

        /// <summary>
        /// Validates hair color
        /// </summary>
        /// <returns>True if hair color is a hexadecimal color</returns>
        private bool ValidateHairColor()
        {
            Regex regexPassportId = new(@"#([0-9a-f]){6}");

            return regexPassportId.IsMatch(this.HairColor);

        }

        /// <summary>
        /// Validates height
        /// </summary>
        /// <returns>True if height is in cm and between 150-193 or 
        /// it is in inches and between 59-76</returns>
        private bool ValidateHeight()
        {
            string unit = Height[(Height.Length- 2)..];
            int minValue, maxValue;

            if (unit.ToLower().Equals("cm"))
            {
                minValue = 150;
                maxValue = 193;
            }
            else
            {
                if (unit.ToLower().Equals("in"))
                {
                    minValue = 59;
                    maxValue = 76;
                }
                else
                {
                    return false;
                }
            }

            return ValidateNumber(int.Parse(this.Height[0..^2]), minValue ,maxValue);

        }

    }
}
