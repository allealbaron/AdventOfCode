using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2022
{
    public class Task02
    {

        private enum PlayerEnum
        {
            One,
            Two
        }

        private enum RoundPlayEnum
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        private enum StrategyEnum
        {
            Lose = 0,
            Draw = 3,
            Win = 6
        }

        private readonly List<Tuple<RoundPlayEnum, RoundPlayEnum>> _winningSituations =
            new ()
            {
                new(RoundPlayEnum.Rock, RoundPlayEnum.Scissors),
                new (RoundPlayEnum.Paper, RoundPlayEnum.Rock),
                new (RoundPlayEnum.Scissors, RoundPlayEnum.Paper)
            };

        /// <summary>
        /// Rounds
        /// </summary>
        private readonly List<Tuple<RoundPlayEnum, RoundPlayEnum>> _rounds = new();

        /// <summary>
        /// Rounds
        /// </summary>
        private readonly List<Tuple<RoundPlayEnum, StrategyEnum>> _roundsWithStrategy = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            return _rounds.Sum(GetTotalScoreTask1);

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return _roundsWithStrategy.Sum(GetTotalScoreTask2);

        }

        private int GetTotalScoreTask2(Tuple<RoundPlayEnum, StrategyEnum> item)
        {

            return (int)item.Item2 + (int)GetItemStrategy(item.Item1, item.Item2); 

        }

        /// <summary>
        /// Given a RoundPlayEnum, returns which
        /// selection could win against it
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>winner</returns>
        private RoundPlayEnum GetWinnerSelection(RoundPlayEnum input)
        {

            return _winningSituations.Single(t=> t.Item2 == input).Item1;

        }

        /// <summary>
        /// Given a RoundPlayEnum, returns which
        /// selection could lose against it
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>loser</returns>
        private RoundPlayEnum GetLoserSelection(RoundPlayEnum input)
        {

            return _winningSituations.Single(t => t.Item1 == input).Item2;

        }

        private RoundPlayEnum GetItemStrategy(RoundPlayEnum roundPlay, StrategyEnum strategy)
        {

            return strategy switch
            {
                StrategyEnum.Draw => roundPlay,
                StrategyEnum.Lose => GetLoserSelection(roundPlay),
                StrategyEnum.Win => GetWinnerSelection(roundPlay),
                _ => throw new Exception("Error")
            };

        }

        private int GetTotalScoreTask1(Tuple<RoundPlayEnum, RoundPlayEnum> item)
        {
            
            return (int)ResolveRound(item, PlayerEnum.Two) + (int)item.Item2;
            
        }


        private StrategyEnum ResolveRound(Tuple<RoundPlayEnum, RoundPlayEnum> item, PlayerEnum player)
        {

            if ((item.Item1 == item.Item2))
            {
                return StrategyEnum.Draw;
            }

            if (player == PlayerEnum.One)
            {
                return (GetWinnerSelection(item.Item2) == item.Item1) 
                        ? StrategyEnum.Win
                        : StrategyEnum.Lose;
            }
            else
            {
                return (GetWinnerSelection(item.Item1) == item.Item2)
                    ? StrategyEnum.Win
                    : StrategyEnum.Lose;
            }

        }

        private StrategyEnum ToStrategy(string input)
        {
            return input switch
            {
                ("X") => StrategyEnum.Lose,
                ("Y") => StrategyEnum.Draw,
                ("Z") => StrategyEnum.Win,
                _ => throw new Exception("Error")
            };
        }

        private RoundPlayEnum ToRoundPlay(string input)
        {
            return input switch
            {
                ("A") => RoundPlayEnum.Rock,
                ("X") => RoundPlayEnum.Rock,
                ("B") => RoundPlayEnum.Paper,
                ("Y") => RoundPlayEnum.Paper,
                ("C") => RoundPlayEnum.Scissors,
                ("Z") => RoundPlayEnum.Scissors,
                _ => throw new Exception("Error")
            };
        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            _rounds.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            string line;
            

            while ((line = sr.ReadLine()) != null)
            {

                var tempLine = line.Split(" ");

                RoundPlayEnum item1 = ToRoundPlay(tempLine[0]);

                _rounds.Add(new Tuple<RoundPlayEnum, RoundPlayEnum>
                            (
                                item1,
                                ToRoundPlay(tempLine[1])
                                ));

                _roundsWithStrategy.Add(new Tuple<RoundPlayEnum, StrategyEnum>
                (
                    item1,
                    ToStrategy(tempLine[1])
                ));

            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task02(string fileName)
        {

            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task02 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
