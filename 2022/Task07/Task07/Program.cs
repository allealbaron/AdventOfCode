using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2022
{
    public class Task07
    {

        /// <summary>
        /// DataStream
        /// </summary>
        private List<string> _commands = new();

        /// <summary>
        /// Root tree
        /// </summary>
        private TreeItem _tree = new() {Name = "/", Size = 0};

        /// <summary>
        /// Max size for folders (Part 1)
        /// </summary>
        private const int MAX_SIZE = 100000;

        /// <summary>
        /// Disk size (part 2)
        /// </summary>
        private const int DISK_SIZE = 70000000;

        /// <summary>
        /// Min unused space required
        /// </summary>
        private const int MIN_UNUSED_SPACE = 30000000;
        

        /// <summary>
        /// Given a path, returns folder size
        /// </summary>
        /// <param name="folderPath">Folder path</param>
        /// <returns>Folder size</returns>
        public int GetSizeSubFolder(string folderPath)
        {
            var parts = folderPath.Split('/');

            var currentItem = _tree;

            if (folderPath != "/")
            {
                
                if (parts.Length > 1)
                {
                    var i = 1;

                    while (i < parts.Length)
                    {
                        currentItem = currentItem.SubItems
                                        .SingleOrDefault(t => t.Name  == parts[i]);

                        i++;
                    }

                }
            }

            return currentItem.GetTotalSize();

        }

        /// <summary>
        /// Loads total tree
        /// </summary>
        private void LoadTree()
        {
            var currentItem = _tree;
            
            foreach (var command in _commands)
            {
                var parts = command.Split(' ');

                if (parts[0] == "$")
                {
                    if (parts[1] == "cd")
                    {
                        switch (parts[2])
                        {
                            case "/":
                                currentItem = _tree;
                                break;
                            case "..":
                                currentItem = currentItem.Parent;
                                break;
                            default:
                                currentItem = currentItem.SubItems.SingleOrDefault(t => t.Name == parts[2]);
                                break;
                        }
                    }
                }
                else
                {
                    currentItem.SubItems.Add(
                        new TreeItem()
                        {
                            Parent = currentItem,
                            Name = parts[1],
                            Size = parts[0] == "dir" ? 0 : int.Parse(parts[0])
                        }
                        );

                }
            }

        }

        /// <summary>
        /// Recursive function to get the sum of items under
        /// a TreeNode <param name="t"></param> which a size smaller than <param name="maxSize"></param>
        /// </summary>
        /// <param name="t">Tree Node from which we </param>
        /// <param name="maxSize">Max size</param>
        /// <returns>Sum of items</returns>
        private int GetSumTotalSize(TreeItem t, int maxSize)
        {

            var result = 0;

            foreach (var item in t.SubItems)
            {
                if (item.Size == 0)
                {

                    var temp = item.GetTotalSize();

                    if (temp < maxSize)
                    {
                        result += temp;
                    }

                    result += GetSumTotalSize(item, maxSize);

                }
            }

            return result;

        }

        /// <summary>
        /// Find the smallest folder to delete
        /// </summary>
        /// <param name="t">Tree from which we search the folder</param>
        /// <param name="minSizeToDelete">Minimum size to delete</param>
        /// <param name="candidate">Candidate item</param>
        /// <returns>Folder's size with the minimum size</returns>
        private int FindSmallestFolderToDelete(TreeItem t, int minSizeToDelete, int candidate)
        {

            foreach (var item in t.SubItems)
            {
                if (item.Size == 0)
                {

                    var temp = item.GetTotalSize();

                    if (temp >= minSizeToDelete && temp<= candidate)
                    {
                        candidate = temp;
                    }

                    candidate = FindSmallestFolderToDelete(item, minSizeToDelete, candidate);

                }
            }

            return candidate;

        }

        /// <summary>
        /// First Part
        /// </summary>
        /// <returns>Result</returns>
        public int FirstPart()
        {
            return GetSumTotalSize(_tree, MAX_SIZE);
        }

        /// <summary>
        /// Second part
        /// </summary>
        public int SecondPart()
        {

            return FindSmallestFolderToDelete(_tree,
                                MIN_UNUSED_SPACE - (DISK_SIZE - GetSizeSubFolder("/")),
                                            DISK_SIZE);

        }

        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="fileName">File name</param>
        private void LoadFile(string fileName)
        {
            _commands.Clear();
            
            const Int32 BufferSize = 128;
            FileStream fs = File.OpenRead(fileName);
            StreamReader sr = new(fs, Encoding.UTF8, true, BufferSize);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                _commands.Add(line);
            }

            LoadTree();

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="fileName">File to load</param>
        public Task07(string fileName)
        {

            LoadFile(fileName);

        }

        /// <summary>
        /// Main Thread
        /// </summary>
        static void Main()
        {
            var fileName = "Input.txt";

            Task07 t = new(fileName);

            Console.WriteLine("First Part: {0}", t.FirstPart());

            Console.WriteLine("Second Part: {0}", t.SecondPart());

        }

    }
}
