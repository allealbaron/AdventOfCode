using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Task08
    {
        /// <summary>
        /// Input data
        /// </summary>
        private readonly List<int> input = new();

        /// <summary>
        /// New node
        /// </summary>
        private readonly List<Node> nodeList = new();

        /// <summary>
        /// Root node
        /// </summary>
        private readonly Node rootNode = new();

        /// <summary>
        /// Loads tree
        /// </summary>
        /// <param name="index">Current index</param>
        /// <param name="parent">Parent node</param>
        /// <returns></returns>
        private int LoadTree(int index, Node parent)
        {
            int childrenNumber = input[index];
            int metadataNumber = input[index+1];
            int newPosition = index+2;
            Node n = new();

            for (int i = 0; i < childrenNumber; i++)
            {
                newPosition = LoadTree(newPosition, n);
            }

            for (int i = 0; i < metadataNumber; i++)
            {
                n.Metadata.Add(input[newPosition]);
                newPosition++;
            }

            parent.ChildNodes.Add(n);
            nodeList.Add(n);

            return newPosition;

        }

        /// <summary>
        /// Returns metadata's sum
        /// </summary>
        /// <param name="n">node</param>
        /// <returns>Sum</returns>
        private int GetSumMetadata(Node n)
        {
            int sum = n.Metadata.Sum();

            foreach (Node son in n.ChildNodes)
            {
                sum += GetSumMetadata(son);
            }

            return sum;

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Value</returns>
        public int FirstPart()
        {

            return GetSumMetadata(rootNode);

        }

        /// <summary>
        /// Given a node id, returns its value
        /// </summary>
        /// <param name="id">Node id</param>
        /// <returns>Value</returns>
        public int GetNodeValue(int id)
        {

            int result = 0;

            Node node = (from n in nodeList
                      where n.Id == id
                      select n).First();

            if (node.ChildNodes.Count == 0)
            {
                result = node.Metadata.Sum();
            }
            else
            {
                foreach (int i in node.Metadata)
                {
                    if (i - 1 < node.ChildNodes.Count)
                    {
                        result += GetNodeValue(node.ChildNodes[i-1].Id);
                    }
                }
            }

            return result;

        }

        /// <summary>
        /// Second Part
        /// </summary>
        /// <returns>Value</returns>
        public int SecondPart()
        {

            return GetNodeValue(1);

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

            input.AddRange((from item in sr.ReadToEnd().Split(" ")
                     select int.Parse(item)).ToList<int>());

            sr.Close();
            fs.Close();
        
        }
      
        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task08(string fileName)
        {
            
            Node.Sequence = 0;
            rootNode = new();
            input.Clear();
            nodeList.Clear();

            nodeList.Add(rootNode);
            LoadFile(fileName);

            _ = LoadTree(0, rootNode);

        }

        static void Main()
        {

            Task08 t = new("input.txt");

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }
    }
}
