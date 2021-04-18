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
        private readonly List<Room> rooms = new();

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFilePart(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                rooms.Add(new(line));
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            return (from r in rooms
                   where r.IsValid()
                   select r.Sector).Sum();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {
            return  (from r in rooms
                    where r.IsValid() && r.DecryptName().Contains("north")
                    select r.Sector).First();
        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task04(string fileName)
        {

            LoadFilePart(fileName);

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

