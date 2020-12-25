using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {

        /// <summary>
        /// Linked List
        /// </summary>
        static Dictionary<string, Bag> Bags = new Dictionary<string, Bag>();

        /// <summary>
        /// Bag to find
        /// </summary>
        static readonly string BagName = "shiny gold";

        /// <summary>
        /// First Part
        /// </summary>
        static void FirstPart()
        {
            Console.WriteLine("First solution:");
            Console.WriteLine("Bags which can contain {0}: {1}", 
                            BagName,
                            ContainerBags(BagName, new HashSet<Bag>()).Count);

        }

        /// <summary>
        /// Recursive function to find how many bags can contain the bag passed as parameter
        /// </summary>
        /// <param name="name">Bag to find</param>
        /// <param name="collection">Collection where the result is stored</param>
        /// <returns>Result</returns>
        static HashSet<Bag> ContainerBags(string name, HashSet<Bag> collection)
        {
            var query = from b in Bags
                    where b.Value.BagsContained.ContainsKey(name)
                    select b.Value;

            foreach (Bag b in query)
            {
                collection.Add(b);
                collection = ContainerBags(b.Name, collection);
            }

            return collection;
        }

        /// <summary>
        /// Second part
        /// </summary>
        static void SecondPart()
        {

            Console.WriteLine("Second solution:");

            Console.WriteLine("Bags contained in {0}: {1}", BagName, 
                              GetBagsContained(BagName));


        }

        /// <summary>
        /// Gets Bags contained by bag
        /// </summary>
        /// <param name="name">Bag name</param>
        /// <returns>Number of bags</returns>
        static int GetBagsContained(string name)
        {
            int result = 0;

            foreach (string bagName in Bags[name].BagsContained.Keys)
            {
                result += Bags[name].BagsContained[bagName].Quantity +
                            Bags[name].BagsContained[bagName].Quantity *
                            GetBagsContained(bagName);
            }

            return result;

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        static void LoadFile(string fileName)
        {

            Bags = new Dictionary<string, Bag>();

            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8, true, BufferSize);
            String line;

            Regex regexLine = new Regex(@"(?<Container>[A-Za-z\s]+)(bags\scontain)(\s(?<Contained>1[A-Za-z\s]+)bag[,.]?|\s(?<Contained>[\d]+[A-Za-z\s]+)bags[,.]?|\s(?<Contained>no other) bags.)+");

            while ((line = sr.ReadLine()) != null)
            {
                Match resultMatch = regexLine.Match(line);

                if (resultMatch.Success)
                {
                    Bag bag = new Bag()
                    {
                        Quantity = 1,
                        Name = resultMatch.Groups["Container"].Captures[0].Value.Trim()
                    };
                    
                    foreach (Capture c in resultMatch.Groups["Contained"].Captures)
                    {
                        Regex regexItem = new Regex(@"(?<Quantity>([\d]+))\s(?<Bag>([A-Za-z\s]+))");

                        Match lineMatch = regexItem.Match(c.Value.Trim());

                        if (lineMatch.Success)
                        {
                            string name = lineMatch.Groups["Bag"].Captures.First().Value;
                            bag.BagsContained.Add(name, new Bag()
                            {
                                Quantity = int.Parse(lineMatch.Groups["Quantity"].Captures.First().Value),
                                Name = name
                            });
                        }
                    }

                    Bags.Add(bag.Name, bag);

                }
            }

            sr.Close();
            fs.Close();


        }

        static void Main()
        {
            List<string> files = new List<string>() { "TestInput.txt" , "TestInput2.txt", "Input.txt" };

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
