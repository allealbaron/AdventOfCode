using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022
{
    public class TreeItem
    {

        public List<TreeItem> SubItems { get; set; } = new();

        public TreeItem Parent { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public int GetTotalSize()
        {
            if (!SubItems.Any())
            {
                return Size;
            }
            else
            {
                return SubItems.Sum(t => t.GetTotalSize());
            }
        }

        public override string ToString()
        {
            return ($"{Name}: {Size}");
        }

    }

}
