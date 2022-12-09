using System.Linq;

namespace AdventOfCode.Year2022
{

      public class Tree
        {
            public int Value { get; set; }

            public bool[] Visible { get; set; } = new bool[4];

            public int[] Scenic { get; set; } = new int[4];

            public Tree(int value)
            {
                Value = value;

                for (var i = 0; i < Visible.Length; i++)
                {
                    Visible[i] = true;
                }

            }

            public bool IsInvisible()
            {
                return Visible.All(t => !t);
            }

            public int GetScenic()
            {
                return Scenic.Aggregate(1, (x, y) => x * y);
            }

            /*
            public override string ToString()
            {
                return $"{Value} {Visible[0].ToString()} {Visible[1].ToString()} {Visible[2].ToString()} {Visible[3].ToString()} --- {IsInvisible()}";
            }
            */

            public override string ToString()
            {
                return $"{Value} {Scenic[0].ToString()} {Scenic[1].ToString()} {Scenic[2].ToString()} {Scenic[3].ToString()}";
            }

    }

}