using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task05
{
    class Program
    {

        /// <summary>
        /// Expenses
        /// </summary>
        static List<BoardingPass> boardingpasses = new List<BoardingPass>();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
           
            Console.WriteLine("First solution:");

            Console.WriteLine("Max Value: {0} ", boardingpasses.Select(p => p.SeatId).Max());


        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            var innerJoin = from b1 in boardingpasses
                            join noItem in boardingpasses on (b1.SeatId+1) equals noItem.SeatId  into joinList
                            from subjoin in joinList.DefaultIfEmpty()
                            from b2 in boardingpasses
                            where (subjoin == null && b1.SeatId == b2.SeatId-2)
                            select new { b1, b2, solution = b1.SeatId+1 };

            Console.WriteLine("Second solution:");
            

            foreach (var item in innerJoin)
            {
                Console.WriteLine("{0} - {1} - Solution: {2} ", item.b1.SeatId, item.b2.SeatId, item.solution);
            }

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            boardingpasses = new List<BoardingPass>();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                boardingpasses.Add(
                new BoardingPass()
                {
                    Row = Convert.ToInt32(line.Substring(0, 7).Replace('B', '1').Replace('F', '0'), 2),
                    Column = Convert.ToInt32(line.Substring(line.Length-3).Replace('R','1').Replace('L','0'), 2)
                });
            }

            sr.Close();
            fs.Close();


        }

        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt", "Input.txt" };

            foreach (string file in files)
            {
                Console.WriteLine("Testing file {0}", file);
                Console.WriteLine();
                Console.WriteLine();

                LoadFile(file);
                FirstPart();
                SecondPart();

                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
