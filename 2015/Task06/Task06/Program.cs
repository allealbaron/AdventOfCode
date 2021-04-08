using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Task06
    {

        /// <summary>
        /// Row side
        /// </summary>
        public const int ROW_SIDE = 1000;

        /// <summary>
        /// Input
        /// </summary>
        private readonly List<List<ILightBulb>> input = new();

        /// <summary>
        /// List of lightbulb orders
        /// </summary>
        private readonly List<LightBulbOrder> lightBulbOrders = new();

        /// <summary>
        /// Creates lightbulbs for the first part
        /// </summary>
        private void CreateLightBulbsFirstPart()
        {

            input.Clear();

            for (int i = 0; i < ROW_SIDE; i++)
            {
                
                List<ILightBulb> lb = new();
                
                for (int j = 0; j < ROW_SIDE; j++)
                {
                    lb.Add(new LightBulbFirstPart());
                }

                input.Add(lb);

            }
        }

        /// <summary>
        /// Creates lightbulbs for the second part
        /// </summary>
        private void CreateLightBulbsSecondPart()
        {
            
            input.Clear();

            for (int i = 0; i < ROW_SIDE; i++)
            {

                List<ILightBulb> lb = new();

                for (int j = 0; j < ROW_SIDE; j++)
                {
                    lb.Add(new LightBulbSecondPart());
                }

                input.Add(lb);

            }
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

            Regex regexLine = new (@"(?<Order>(turn on|turn off|toggle))(?<FirstSpace>\s)" +
                                        @"(?<Init>[\d]+,[\d]+)(?<Through>\s(through)\s)(?<End>[\d]+,[\d]+)");
                
                
            while ((line = sr.ReadLine()) != null)
            {
                Match resultMatch = regexLine.Match(line);

                LightBulbOrder.LightBulbOrderEnum order = LightBulbOrder.LightBulbOrderEnum.TurnOn;

                switch (resultMatch.Groups["Order"].Captures.First().Value.ToLower())
                {
                    case "turn on":
                        order = LightBulbOrder.LightBulbOrderEnum.TurnOn;
                        break;
                    case "turn off":
                        order = LightBulbOrder.LightBulbOrderEnum.TurnOff;
                        break;
                    case "toggle":
                        order = LightBulbOrder.LightBulbOrderEnum.Toggle;
                        break;
                }

                lightBulbOrders.Add(new ()
                {
                    Order = order,
                    InitPoint = new (
                                    int.Parse(resultMatch.Groups["Init"].Captures.FirstOrDefault().ToString().Split(',')[0]),
                                    int.Parse(resultMatch.Groups["Init"].Captures.FirstOrDefault().ToString().Split(',')[1])
                                ),
                    EndPoint = new (
                                    int.Parse(resultMatch.Groups["End"].Captures.FirstOrDefault().ToString().Split(',')[0]),
                                    int.Parse(resultMatch.Groups["End"].Captures.FirstOrDefault().ToString().Split(',')[1])
                                ),
                });

            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task06(string fileName)
        {

            LoadFile(fileName);

        }

        /// <summary>
        /// Executes orders
        /// </summary>
        private void ExecuteOrders()
        {

            foreach (LightBulbOrder lbo in lightBulbOrders)
            {
                for (int i = lbo.InitPoint.X; i <= lbo.EndPoint.X; i++)
                {
                    for (int j = lbo.InitPoint.Y; j <= lbo.EndPoint.Y; j++)
                    {
                        switch (lbo.Order)
                        {
                            case LightBulbOrder.LightBulbOrderEnum.TurnOn:
                                input[i][j].TurnOn();
                                break;
                            case LightBulbOrder.LightBulbOrderEnum.TurnOff:
                                input[i][j].TurnOff();
                                break;
                            case LightBulbOrder.LightBulbOrderEnum.Toggle:
                                input[i][j].Toggle();
                                break;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            CreateLightBulbsFirstPart();

            ExecuteOrders();

            return (from line in input
                    from lightBulb in line
                    where  ((LightBulbFirstPart)lightBulb).GetStatus() == LightBulbFirstPart.StatusEnum.On
                    select lightBulb).Count();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            CreateLightBulbsSecondPart();

            ExecuteOrders();

            return (from line in input
                    from lightBulb in line
                    select ((LightBulbSecondPart)lightBulb).GetBrightness()).Sum();

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task06 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}

