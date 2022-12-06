using System;
using System.IO;
using System.Text;

namespace AdventOfCode.Year2022
{
    public class Task06
    {

        /// <summary>
        /// DataStream
        /// </summary>
        private string _datastream = string.Empty;

        private const int FIRST_SECTION_SIZE = 4;

        private const int SECOND_SECTION_SIZE = 14;

        private int FindStartOfMessage(int sectionSize)
        {
            for (var i = 0; i < _datastream.Length - sectionSize; i++)
            {
                var skip = false;

                for (var j = 0; (j < sectionSize) && !skip; j++)
                {
                    for (var k = j + 1; (k < sectionSize) && !skip; k++)
                    {
                        if (_datastream[i + j] == _datastream[i + k])
                        {
                            skip = true;
                        }
                    }
                }

                if (!skip)
                {
                    return (i + sectionSize);
                }
            }

            return 0;

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {

            return FindStartOfMessage(FIRST_SECTION_SIZE);

        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return FindStartOfMessage(SECOND_SECTION_SIZE);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            _datastream = string.Empty;
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);

            _datastream = sr.ReadToEnd();
            
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
        /// Main Thread
        /// </summary>
        static void Main()
        {
            var fileName = "Input.txt";
            Task06 t = new(fileName);

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
