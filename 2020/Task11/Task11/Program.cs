using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task11
{
    class Program
    {

        /// <summary>
        /// Waiting Area
        /// </summary>
        static WaitingRoom WaitingRoom = new WaitingRoom();

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
           

            Console.WriteLine("First solution: {0}", WaitingRoom.FillWaitingRoom());

           

        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            Console.WriteLine("Second solution: {0}", WaitingRoom.FillWaitingRoomPart2());

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {
            WaitingRoom = new WaitingRoom();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                WaitingRoom.RoomConfiguration.Add(line.ToCharArray().ToList<char>());
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
                LoadFile(file);
                SecondPart();

                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
