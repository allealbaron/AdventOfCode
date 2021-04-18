using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Room
    {

        /// <summary>
        /// Characters
        /// </summary>
        private static readonly char[] CHARACTERS = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        /// <summary>
        /// Regex Line
        /// </summary>
        private static readonly Regex RegexLine = new(@"(?<Name>([a-z]|-)*)-(?<Sector>([\d]+))\[(?<CheckSum>([a-z])+)\]");

        /// <summary>
        /// Entire room name, with checksum and Sector. It can be not valid
        /// </summary>
        public string EntireName { get; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// CheckSum
        /// </summary>
        public string CheckSum { get; }

        /// <summary>
        /// Sector
        /// </summary>
        public int Sector { get; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="entireName">name</param>
        public Room(string entireName)
        {

            this.EntireName = entireName;
            
            Match match = RegexLine.Match(entireName);

            this.Name = match.Groups["Name"].Captures.First().Value;
            this.CheckSum = match.Groups["CheckSum"].Captures.First().Value;
            this.Sector = int.Parse(match.Groups["Sector"].Captures.First().Value);

        }

        /// <summary>
        /// Returns if a <see cref="Room"/> is valid
        /// </summary>
        /// <returns>True if it is valid</returns>
        public bool IsValid()
        {

            return String.Concat(from c in this.Name.Replace("-", String.Empty).ToCharArray()
                    group c by c into groups
                    orderby groups.Count() descending, groups.Key ascending
                    select groups.Key).Substring(0, 5).Equals(this.CheckSum);

        }

        /// <summary>
        /// Decrypt room's name
        /// </summary>
        /// <returns>Room's name decrypted</returns>
        public string DecryptName()
        {
            List<char> result = new();

            foreach (char c in this.Name)
            {
                if (c.Equals('-'))
                {
                    result.Add(' ');
                }
                else 
                {
                    result.Add(CHARACTERS[(Array.IndexOf(CHARACTERS, c) + this.Sector) % CHARACTERS.Length]);
                }
            }

            return string.Concat(result);

        }

    }
}
