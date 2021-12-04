using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task04
    {

        /// <summary>
        /// Bingo Numbers
        /// </summary>
        private readonly List<int> bingoNumbers = new();

        private readonly List<BingoCard> bingoCards = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            foreach (int number in bingoNumbers)
            {
                foreach (BingoCard bc in bingoCards)
                {
                    bc.CheckNumber(number);
                    if (bc.HasLine())
                    {
                        return bc.GetCardScore() * number;
                    }
                }
            }

            return 0;

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            foreach (int number in bingoNumbers)
            {
                foreach (BingoCard bc in bingoCards.Where(c => !c.HasLine()))
                {
                    bc.CheckNumber(number);
                    if (!bingoCards.Where(c => !c.HasLine()).Any())
                    {
                        return bc.GetCardScore() * number;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            bingoNumbers.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            foreach (string numberAsString in sr.ReadLine().Split(','))
            {
                bingoNumbers.Add(Int32.Parse(numberAsString));
            }

            _ = sr.ReadLine();

            BingoCard tempBingoCard = new();

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Trim().Equals(String.Empty))
                {
                    if (!(tempBingoCard is null))
                    {
                        bingoCards.Add(tempBingoCard);
                    }
                    tempBingoCard = new BingoCard();
                }
                else
                {
                    List<BingoNumber> bingoCardLine = new();

                    foreach (string numberAsString in line.Split(' '))
                    {
                        if (!(numberAsString.Equals(String.Empty)))
                        {
                            bingoCardLine.Add(new BingoNumber(Int32.Parse(numberAsString)));
                        }
                    }

                    tempBingoCard.Card.Add(bingoCardLine);

                }
            }

            bingoCards.Add(tempBingoCard);

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task04(string fileName)
        {
            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task04 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
