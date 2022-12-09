using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2022
{
    public class Task08
    {

        private enum Position
        {
            Top = 0,
            Right = 1,
            Bottom = 2,
            Left = 3
        }

        /// <summary>
        /// DataStream
        /// </summary>
        private IList<IList<Tree>> _trees = new List<IList<Tree>>();

        /// <summary>
        /// Sets Visibilities for first part
        /// </summary>
        private void SetVisibilities()
        {

            // From left visibility

            for (var i = 0; i < _trees[0].Count; i++)
            {
                _trees[i][0].Visible[(int)Position.Left] = true;
            }

            for (var i = 0; i < _trees.Count; i++)
            {
                var maxLeftSize = _trees[i][0].Value;

                for (var j = 1; j < _trees.Count; j++)
                {
                    _trees[i][j].Visible[(int)Position.Left] =
                        _trees[i][j].Value > maxLeftSize;

                    if (_trees[i][j].Value > maxLeftSize)
                    {
                        maxLeftSize = _trees[i][j].Value;
                    }

                }
            }

            // From right visibility

            for (var i = 0; i < _trees[0].Count; i++)
            {
                _trees[i][^1].Visible[(int)Position.Right] = true;
            }

            for (var i = 0; i < _trees.Count; i++)
            {
                var maxRightSize = _trees[i][^1].Value;

                for (var j = _trees[i].Count-2; j >= 0; j--)
                {
                    _trees[i][j].Visible[(int)Position.Right] =
                        _trees[i][j].Value > maxRightSize;

                    if (_trees[i][j].Value > maxRightSize)
                    {
                        maxRightSize = _trees[i][j].Value;
                    }

                }
            }

            // From top visibility

            for (var j = 0; j < _trees.Count; j++)
            {
                _trees[0][j].Visible[(int)Position.Top] = true;
            }

            for (var j = 1; j < _trees.Count; j++)
            {
                var maxTopSize = _trees[0][j].Value;

                for (var i = 0; i < _trees[j].Count; i++)
                {
                    _trees[i][j].Visible[(int)Position.Top] =
                        _trees[i][j].Value > maxTopSize;

                    if (_trees[i][j].Value > maxTopSize)
                    {
                        maxTopSize = _trees[i][j].Value;
                    }

                }
            }

            // From bottom visibility

            for (var j = 0; j < _trees[0].Count; j++)
            {
                _trees[^1][j].Visible[(int)Position.Bottom] = true;
            }

            for (var j = _trees.Count -1; j > 0; j--)
            {
                var maxBottomSize = _trees[^1][j].Value;

                for (var i = _trees[j].Count - 2; i > 0; i--)
                {
                    _trees[i][j].Visible[(int)Position.Bottom] =
                        _trees[i][j].Value > maxBottomSize;

                    if (_trees[i][j].Value > maxBottomSize)
                    {
                        maxBottomSize = _trees[i][j].Value;
                    }

                }
            }

        }

        private void SetScenics()
        {

            // For left scenics

            for (var i = 0; i < _trees[0].Count; i++)
            {
                _trees[i][0].Scenic[(int)Position.Left] = 0;
                _trees[i][1].Scenic[(int)Position.Left] = 1;
            }
            
            for (var i = 0; i < _trees.Count; i++)
            {

                for (var j = 2; j < _trees.Count; j++)
                {

                    var k = j - 1;

                    while (k >= 0)
                    {

                        _trees[i][j].Scenic[(int)Position.Left]++;

                        if (_trees[i][j].Value <= _trees[i][k].Value)
                        {
                            k = 0;
                        }

                        k--;
                    }

                }
               
            }

            // For right scenics

            for (var i = 0; i < _trees[0].Count; i++)
            {
                _trees[i][^1].Scenic[(int)Position.Right] = 0;
                _trees[i][^2].Scenic[(int)Position.Right] = 1;
            }

            for (var i = 0; i < _trees.Count; i++)
            {

                for (var j = 0; j < _trees.Count-1; j++)
                {

                    var k = j + 1;

                    while (k < _trees[i].Count)
                    {

                        _trees[i][j].Scenic[(int)Position.Right]++;

                        if (_trees[i][j].Value <= _trees[i][k].Value)
                        {
                            k = _trees[i].Count;
                        }

                        k++;

                    }

                }

            }

            // For top scenics

            for (var j = 0; j < _trees.Count; j++)
            {
                _trees[0][j].Scenic[(int)Position.Top] = 0;
                _trees[1][j].Scenic[(int)Position.Top] = 1;
            }

            for (var i = 2; i < _trees.Count; i++)
            {

                for (var j = 0; j < _trees.Count; j++)
                {

                    var k = i - 1;

                    while (k >= 0)
                    {

                        _trees[i][j].Scenic[(int)Position.Top]++;

                        if (_trees[i][j].Value <= _trees[k][j].Value)
                        {
                            k = 0;
                        }

                        k--;

                    }

                }

            }

            // For bottom scenics

            for (var j = 0; j < _trees.Count; j++)
            {
                _trees[^1][j].Scenic[(int)Position.Bottom] = 0;
                _trees[^2][j].Scenic[(int)Position.Bottom] = 1;
            }

            for (var i = 0; i < _trees.Count - 2 ; i++)
            {

                for (var j = 0; j < _trees.Count; j++)
                {

                    var k = i + 1;

                    while (k < _trees.Count)
                    {

                        _trees[i][j].Scenic[(int)Position.Bottom]++;

                        if (_trees[i][j].Value <= _trees[k][j].Value)
                        {
                            k = _trees.Count;
                        }

                        k++;

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
            return _trees.SelectMany(line => line).Count(tree => !tree.IsInvisible());
        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return _trees.SelectMany(line => line).Max(tree => tree.GetScenic());

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            _trees.Clear();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                var tempList = new List<Tree>();
                
                foreach (var item in line)
                {
                    tempList.Add(new Tree(int.Parse(item.ToString())));
                }

                _trees.Add(tempList);

            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task08(string fileName)
        {

            LoadFile(fileName);

            SetVisibilities();

            SetScenics();

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            var fileName = "Input.txt";

            Task08 t = new(fileName);

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
