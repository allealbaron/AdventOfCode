using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021
{
    public class Task05
    {

        /// <summary>
        /// Coordenates size
        /// </summary>
        private const int SIZE = 1000;

        /// <summary>
        /// Input
        /// </summary>
        private readonly List<Tuple<VentCoordenate, VentCoordenate>> input = new();

        /// <summary>
        /// Coordenates
        /// </summary>
        private readonly List<VentCoordenate> coordenates = new(SIZE * SIZE);

        /// <summary>
        /// Calculates values for horizontal lines
        /// </summary>
        private void CalculateHorizontals()
        {

            foreach (Tuple<VentCoordenate, VentCoordenate> tupleCoordenate in input.Where(t => t.Item1.X == t.Item2.X))
            {

                for (int i = Math.Min(tupleCoordenate.Item1.Y, tupleCoordenate.Item2.Y);
                     i <= Math.Max(tupleCoordenate.Item1.Y, tupleCoordenate.Item2.Y); i++)
                {
                    coordenates[(SIZE * tupleCoordenate.Item1.X) + i].Value++;
                }

            }

        }

        /// <summary>
        /// Calculates values for vertical lines
        /// </summary>
        private void CalculateVerticals()
        {

            foreach (Tuple<VentCoordenate, VentCoordenate> tupleCoordenate in input.Where(t => t.Item1.Y == t.Item2.Y))
            {

                for (int i = Math.Min(tupleCoordenate.Item1.X, tupleCoordenate.Item2.X);
                     i <= Math.Max(tupleCoordenate.Item1.X, tupleCoordenate.Item2.X); i++)
                {
                    coordenates[(SIZE * i) + tupleCoordenate.Item1.Y].Value++;
                }

            }

        }

        /// <summary>
        /// Calculates values for diagonal lines
        /// </summary>
        private void CalculateDiagonals()
        {

            foreach (Tuple<VentCoordenate, VentCoordenate> tupleCoordenate in input.Where(t => t.Item1.X != t.Item2.X && t.Item1.Y != t.Item2.Y))
            {

                VentCoordenate fromCoordinate = tupleCoordenate.Item1;
                VentCoordenate toCoordinate = tupleCoordenate.Item2;

                if (tupleCoordenate.Item1.X > tupleCoordenate.Item2.X)
                {
                    fromCoordinate = tupleCoordenate.Item2;
                    toCoordinate = tupleCoordenate.Item1;
                }

                for (int i = 0; i <= toCoordinate.X - fromCoordinate.X; i++)
                {
                    if (fromCoordinate.Y < toCoordinate.Y)
                    {
                        coordenates[(SIZE * (fromCoordinate.X + i)) + (fromCoordinate.Y + i)].Value++;
                    }
                    else
                    {
                        coordenates[(SIZE * (fromCoordinate.X + i)) + (fromCoordinate.Y - i)].Value++;
                    }
                }

            }

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            ResetCoordinates();

            CalculateHorizontals();

            CalculateVerticals();

            return coordenates.Where(t => t.Value > 1).Count();

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            ResetCoordinates();

            CalculateHorizontals();

            CalculateVerticals();

            CalculateDiagonals();

            return coordenates.Where(t => t.Value > 1).Count();

        }

        /// <summary>
        /// Generate a <see cref="VentCoordenate"/>
        /// </summary>
        /// <param name="input">Input</param>
        /// <returns>new <see cref="VentCoordenate"/></returns>
        private static VentCoordenate GenerateVentCoordenate(string input)
        {
            string[] points = input.Split(',');

            return new VentCoordenate(Int32.Parse(points[0]), Int32.Parse(points[1]), 0);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            input.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(" -> ");

                input.Add(new Tuple<VentCoordenate, VentCoordenate> (GenerateVentCoordenate(parts[0]) , GenerateVentCoordenate(parts[1]) ) );

            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Resets coordinates
        /// </summary>
        private void ResetCoordinates()
        {

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    coordenates.Add(new VentCoordenate(i, j, 0));
                }
            }

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task05(string fileName)
        {

            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            Task05 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
