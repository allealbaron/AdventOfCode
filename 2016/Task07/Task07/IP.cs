using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class IP
    {

        /// <summary>
        /// Regex
        /// </summary>
        private readonly static Regex regexLine = new(@"^((?<NoBrackets>[a-z]+)(?<Brackets>(\[[a-z]+\])))+(?<NoBrackets>[a-z]+)$");

        /// <summary>
        /// No brackets sectors
        /// </summary>
        public List<string> NoBracketsSectors { get; set; }

        /// <summary>
        /// Brackets sectors
        /// </summary>
        public List<string> BracketsSectors { get; set; }

        /// <summary>
        /// Class builder
        /// </summary>
        public IP()
        {
            this.NoBracketsSectors = new();
            this.BracketsSectors = new();
        }

        /// <summary>
        /// Class builder
        /// </summary>
        /// <param name="input">String with the IP</param>
        public IP(string input)
        {

            this.NoBracketsSectors = new();
            this.BracketsSectors = new();

            Match resultMatch = regexLine.Match(input);

            this.NoBracketsSectors.AddRange(resultMatch.Groups["NoBrackets"].Captures.Select(p => p.ToString()));

            this.BracketsSectors.AddRange(resultMatch.Groups["Brackets"].Captures.Select(p => p.ToString()));

        }

        /// <summary>
        /// Returns if the item contains ABBA
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>True if it contains at least a ABBA pattern</returns>
        private static bool ContainsABBA(string input)
        {
            var inputAsArray = from p in input.ToCharArray().Select((p, i) => new { character = p, Index = i }) select p;

            return (from c1 in inputAsArray
                     from c2 in inputAsArray
                     from c3 in inputAsArray
                     from c4 in inputAsArray
                     where !(c1.character.Equals(c2.character)) && (c2.character.Equals(c3.character)) &&
                           !(c3.character.Equals(c4.character)) && (c1.character.Equals(c4.character))
                           && (c1.Index == c2.Index - 1)
                           && (c2.Index == c3.Index - 1) && (c3.Index == c4.Index - 1)
                     select c1).Any();

        }

        /// <summary>
        /// Returns true if the IP is valid por ABA
        /// </summary>
        /// <returns>True if the IP is valid</returns>
        public bool IsValidForABA()
        {

            var nobracketsABA = (from p1 in this.NoBracketsSectors
                    from p1c1 in p1.ToCharArray().Select((p, i) => new { character = p, Index = i })
                    from p1c2 in p1.ToCharArray().Select((p, i) => new { character = p, Index = i })
                    from p1c3 in p1.ToCharArray().Select((p, i) => new { character = p, Index = i })
                    where !(p1c1.character.Equals(p1c2.character)) && (p1c1.character.Equals(p1c3.character))
                            && (p1c1.Index == p1c2.Index - 1) && (p1c2.Index == p1c3.Index - 1)
                    select new { c1= p1c1.character, c2= p1c2.character }).Distinct();

            var bracketsABA = (from p1 in this.BracketsSectors
                             from p1c1 in p1.ToCharArray().Select((p, i) => new { character = p, Index = i })
                             from p1c2 in p1.ToCharArray().Select((p, i) => new { character = p, Index = i })
                             from p1c3 in p1.ToCharArray().Select((p, i) => new { character = p, Index = i })
                             where !(p1c1.character.Equals(p1c2.character)) && (p1c1.character.Equals(p1c3.character))
                                     && (p1c1.Index == p1c2.Index - 1) && (p1c2.Index == p1c3.Index - 1)
                             select new { c1 = p1c1.character, c2 = p1c2.character }).Distinct();

            return (from t1 in nobracketsABA
                    from t2 in bracketsABA
                    where t1.c1 == t2.c2 && t1.c2 == t2.c1
                    select t1
                    ).Any();

        }

        /// <summary>
        /// Returns true if the IP is valid for ABBA
        /// </summary>
        /// <returns>True if the IP is valid for ABBA</returns>
        public bool IsValidForABBA()
        {

            return (this.NoBracketsSectors.Where(p => ContainsABBA(p)).Any() && 
                    !this.BracketsSectors.Where(p => ContainsABBA(p)).Any());

        }

    }
}
