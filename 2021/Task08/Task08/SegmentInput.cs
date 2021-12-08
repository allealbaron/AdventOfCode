using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    /// <summary>
    /// Segment Input
    /// </summary>
    public class SegmentInput
    {

        /// <summary>
        /// Segments
        /// </summary>
        public Dictionary<char, int> Segments { get; set; }

        /// <summary>
        /// Digits
        /// </summary>
        public List<SegmentDigit> Digits { get; set; }

        /// <summary>
        /// Number Displayed
        /// </summary>
        public List<string> NumbersDisplayed { get; set; }

        /// <summary>
        /// Class builder
        /// </summary>
        /// <param name="input">Input</param>
        public SegmentInput(string input)
        {
            Segments = new Dictionary<char, int>();
            Digits = new List<SegmentDigit>();
            NumbersDisplayed = new List<string>();

            string[] splitBar = input.Split(" | ");

            foreach (string str in splitBar[0].Trim().Split())
            {
                Digits.Add(new(new (str.OrderBy(c => c).ToArray())));
            }

            foreach (string str in splitBar[1].Trim().Split())
            {
                NumbersDisplayed.Add(new (str.OrderBy(c => c).ToArray()));
            }

            for (char i = 'a'; i <= 'g'; i++)
            {
                Segments.Add(i, -1);
            }

            DecodeDigits();
            DecodeSegments();

        }

        /// <summary>
        /// Decode the digits provided
        /// </summary>
        private void DecodeDigits()
        {

            Digits.FirstOrDefault(p => p.CodeValue.Length == 2).DigitValue = 1;
            Digits.FirstOrDefault(p => p.CodeValue.Length == 4).DigitValue = 4;
            Digits.FirstOrDefault(p => p.CodeValue.Length == 3).DigitValue = 7;
            Digits.FirstOrDefault(p => p.CodeValue.Length == 7).DigitValue = 8;

            (from d in Digits.Where(t => t.CodeValue.Length == 6 && t.DigitValue == -1)
             from one in Digits.Where(t => t.DigitValue == 1).Select(t => t.CodeValue.ToList<char>())
             where !one.All(t => d.CodeValue.Contains(t))
             select d).FirstOrDefault().DigitValue = 6;

            (from d in Digits.Where(t => t.CodeValue.Length == 5 && t.DigitValue == -1)
             from six in Digits.Where(t => t.DigitValue == 6)
             where d.CodeValue.ToList<char>().All(t => six.CodeValue.ToList<char>().Contains(t))
             select d).FirstOrDefault().DigitValue = 5;

            (from d in Digits.Where(t => t.CodeValue.Length == 5 && t.DigitValue == -1)
             from one in Digits.Where(t => t.DigitValue == 1).Select(t => t.CodeValue.ToList<char>())
             where !one.All(t => d.CodeValue.Contains(t))
             select d).FirstOrDefault().DigitValue = 2;

            Digits.FirstOrDefault(t => t.CodeValue.Length == 5 && t.DigitValue == -1).DigitValue = 3;

            (from d in Digits.Where(t => t.CodeValue.Length == 6 && t.DigitValue == -1)
             from four in Digits.Where(t => t.DigitValue == 4).Select(t => t.CodeValue.ToList<char>())
             where four.All(t => d.CodeValue.Contains(t))
             select d).FirstOrDefault().DigitValue = 9;

            Digits.FirstOrDefault(t => t.CodeValue.Length == 6 && t.DigitValue == -1).DigitValue = 0;

        }

        /// <summary>
        /// Decodes the Segments
        /// </summary>
        public void DecodeSegments()
        {

            Segments[Digits.Where(p => p.DigitValue == 1).FirstOrDefault().CodeValue.ToList<char>()
                    .Except(Digits.Where(p => p.DigitValue == 2).FirstOrDefault().CodeValue.ToList<char>()).FirstOrDefault()] = 5;

            Segments[Digits.Where(p => p.DigitValue == 1).FirstOrDefault().CodeValue.ToList<char>()
                    .Except(Segments.Where(s => s.Value != -1).Select(p => p.Key)).FirstOrDefault()] = 2;

            Segments[Digits.Where(p => p.DigitValue == 7).FirstOrDefault().CodeValue.ToList<char>()
                    .Except(Digits.Where(p => p.DigitValue == 1).FirstOrDefault().CodeValue.ToList<char>()).FirstOrDefault()] = 0;

            Segments[Digits.Where(p => p.DigitValue == 6).FirstOrDefault().CodeValue.ToList<char>()
                    .Except(Digits.Where(p => p.DigitValue == 5).FirstOrDefault().CodeValue.ToList<char>()).FirstOrDefault()] = 4;

            Segments[Digits.Where(p => p.DigitValue == 8).FirstOrDefault().CodeValue.ToList<char>()
                    .Except(Digits.Where(p => p.DigitValue == 0).FirstOrDefault().CodeValue.ToList<char>()).FirstOrDefault()] = 3;

            Segments[Digits.Where(p => p.DigitValue == 9).FirstOrDefault().CodeValue.ToList<char>()
                    .Except(Digits.Where(p => p.DigitValue == 3).FirstOrDefault().CodeValue.ToList<char>()).FirstOrDefault()] = 1;

            Segments[Segments.Where(p => p.Value == -1).FirstOrDefault().Key] = 6;

        }

        /// <summary>
        /// Gets the value the four seven-segment display shall show
        /// </summary>
        /// <returns>Value</returns>
        public int GetValue()
        {
            StringBuilder result = new();

            foreach (string s in NumbersDisplayed)
            {
                result.Append(Digits.FirstOrDefault(t=> t.CodeValue.Equals(s)).DigitValue);
            }

            return Int32.Parse(result.ToString());
        }

    }
}