using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Task04
    {
        /// <summary>
        /// Input
        /// </summary>
        private readonly List<GuardActivityInput> input = new();

        /// <summary>
        /// Guard activities
        /// </summary>
        private readonly List<GuardActivity> guardActivities = new();

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            int sleepyId = (from g in (from g in guardActivities
                    where g.TimeStamp.Hour >= 0 && g.TimeStamp.Hour < 1
                         && !g.Awake 
                    select g)
                    group g by g.GuardId into sleeping
                    orderby sleeping.Count() descending 
                    select sleeping.Key).First();

            int maxMinute = (from g in (from g in guardActivities
                                where g.TimeStamp.Hour >= 0 && g.TimeStamp.Hour < 1
                                    && !g.Awake && g.GuardId == sleepyId
                                select g)
                     group g by g.TimeStamp.Minute into minutes
                     orderby minutes.Count() descending
                     select minutes.Key).First();

             return maxMinute * sleepyId;

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {
            return ((from g in (from g in guardActivities
                                         where g.TimeStamp.Hour >= 0 && g.TimeStamp.Hour < 1
                                              && !g.Awake
                                         select g)
                              group g by new { g.TimeStamp.Minute, g.GuardId } into minutes
                              select new
                              {
                                  minutes.Key.GuardId,
                                  minutes.Key.Minute,
                                  Quantity = minutes.Count(),
                                  Product = minutes.Key.GuardId * minutes.Key.Minute
                              }
                            ).ToList()).OrderByDescending(t => t.Quantity).First().Product;

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            Regex regexLine = new(@"\[(?<Year>(\d){4})-(?<Month>(\d){2})-(?<Day>(\d){2})\s(?<Hour>(\d){2}):(?<Minute>(\d){2})\]\s(?<Activity>(wakes\sup|falls\sasleep|Guard\s#(?<GuardId>(\d)+)\sbegins\sshift){1})");

            while ((line = sr.ReadLine()) != null)
            {

                Match resultMatch = regexLine.Match(line);

                GuardActivityInput.GuardActivityEnum activity = resultMatch.Groups["Activity"].Captures.First().Value switch
                {
                    "wakes up" => GuardActivityInput.GuardActivityEnum.WakesUp,
                    "falls asleep" => GuardActivityInput.GuardActivityEnum.FallsAsleep,
                    _ => GuardActivityInput.GuardActivityEnum.BeginsShift,
                };

                int guardId = 0;

                if (activity == GuardActivityInput.GuardActivityEnum.BeginsShift)
                {
                    guardId = int.Parse(resultMatch.Groups["GuardId"].Captures.First().Value);
                }

                input.Add(new()
                {
                    TimeStamp = new DateTime(int.Parse(resultMatch.Groups["Year"].Captures.First().Value),
                                             int.Parse(resultMatch.Groups["Month"].Captures.First().Value),
                                             int.Parse(resultMatch.Groups["Day"].Captures.First().Value),
                                             int.Parse(resultMatch.Groups["Hour"].Captures.First().Value),
                                             int.Parse(resultMatch.Groups["Minute"].Captures.First().Value),
                                             0
                                             ),
                    Activity = activity,
                    GuardId = guardId

                });
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Fills Guards ids
        /// </summary>
        private void FillGuardsId()
        {
            input.Sort();

            int currentGuardId = 0;

            foreach (GuardActivityInput gai in input)
            {

                if (gai.Activity == GuardActivityInput.GuardActivityEnum.BeginsShift)
                {
                    currentGuardId = gai.GuardId;
                }
                else {
                    gai.GuardId = currentGuardId;
                }
            }

        }

        /// <summary>
        /// Fills Guards' activities
        /// </summary>
        private void FillGuardActivities()
        {

            GuardActivity ga = new();

            foreach (GuardActivityInput gai in input)
            {

                if (guardActivities.Count>0 && guardActivities.Last().GuardId != gai.GuardId)
                {
                    DateTime newDate = guardActivities.Last().TimeStamp.AddMinutes(1);

                    while (newDate.Hour < 1)
                    {
                        guardActivities.Add(new()
                        {
                            GuardId = guardActivities.Last().GuardId,
                            Awake = guardActivities.Last().Awake,
                            TimeStamp = newDate
                        });
                        newDate = newDate.AddMinutes(1);
                    }
                }

                if (gai.Activity == GuardActivityInput.GuardActivityEnum.BeginsShift)
                {
                    guardActivities.Add( new()
                    {
                        GuardId = gai.GuardId,
                        Awake = true,
                        TimeStamp = gai.TimeStamp
                    });
                }
                else
                {
                    DateTime newDate = guardActivities.Last().TimeStamp.AddMinutes(1);

                    while (newDate < gai.TimeStamp)
                    {
                        guardActivities.Add(new()
                        {
                            GuardId = guardActivities.Last().GuardId,
                            Awake = guardActivities.Last().Awake,
                            TimeStamp = newDate
                        });
                        newDate = newDate.AddMinutes(1);
                    }

                    guardActivities.Add(new()
                    {
                        GuardId = gai.GuardId,
                        Awake = !guardActivities.Last().Awake,
                        TimeStamp = gai.TimeStamp
                    });

                }
            }

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task04(string fileName)
        {


            LoadFile(fileName);

            FillGuardsId();

            FillGuardActivities();

        }

        static void Main()
        {

            Task04 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
