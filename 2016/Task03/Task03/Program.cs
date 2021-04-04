using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Task03
    {

        /// <summary>
        /// Input
        /// </summary>
        private readonly List<Triangle> triangles = new();

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFilePart1(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                triangles.Add(new() 
                    { 
                        Sides = line.Trim().Split(' ')
                                    .ToList<string>()
                                    .Where(p => p.Trim() != String.Empty)
                                    .Select(p=> Int32.Parse(p)).ToList<int>() });
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFilePart2(string fileName)
        {

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            List<Triangle> tempTriangles = new();
            for (int i = 0; i < 3; i++)
            {
                tempTriangles.Add(new());
            }

            int counter = 0;

            while ((line = sr.ReadLine()) != null)
            {
                List<int> sidesInLine = line.Trim().Split(' ')
                                    .ToList<string>()
                                    .Where(p => p.Trim() != String.Empty)
                                    .Select(p => Int32.Parse(p)).ToList<int>();

                for (int i = 0; i < sidesInLine.Count; i++)
                {
                    tempTriangles[i].Sides.Add(sidesInLine[i]);
                }

                counter++;

                if (counter == 3)
                {
                    triangles.AddRange(tempTriangles);
                    tempTriangles = new (3);
                    for (int i = 0; i < 3; i++)
                    {
                        tempTriangles.Add(new());
                    }
                    counter = 0;
                }

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

            return triangles.Where(p => p.Validate()).Count();

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            return triangles.Where(p => p.Validate()).Count();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task03(string fileName, int part)
        {
            if (part == 1)
            {
                LoadFilePart1(fileName);
            }
            else
            {
                LoadFilePart2(fileName);
            }

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task03 t = new("test02.txt",1);

            Console.WriteLine("First Part: {0}", t.FirstPart());

            t = new("test02.txt", 2);

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}

