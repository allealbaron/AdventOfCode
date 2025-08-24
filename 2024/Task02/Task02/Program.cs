using System.Text;

namespace Task02;

public class Program
{

    private readonly List<List<int>> _input;

    private enum DirectionEnum
    {
        Increasing = 0,
        Decreasing = 1
    }

    /// <summary>
    /// Loads file
    /// </summary>
    /// <param name="fileName">File name</param>
    private void LoadFile(string fileName)
    {
        const int bufferSize = 128;

        using var fs = File.OpenRead(fileName);
        using var sr = new StreamReader(fs, Encoding.UTF8, true, bufferSize);

        while (sr.ReadLine() is { } line)
        {
            _input.Add(line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
        }

    }

    private static bool IsSafe(List<int> input)
    {
        const int maxDiffer = 3;

        if (input[0] == input[1])
        {
            return false;
        }

        var direction = input[0] > input[1] ? DirectionEnum.Decreasing : DirectionEnum.Increasing;

        for (var i = 0; i < input.Count - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                return false;
            }

            if (Math.Abs(input[i] - input[i + 1]) > maxDiffer)
            {
                return false;
            }

            if (direction == DirectionEnum.Decreasing && input[i] < input[i + 1])
            {
                return false;
            }

            if (direction == DirectionEnum.Increasing && input[i] > input[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    public int Part01()
    {
        return _input.Count(IsSafe);
    }

    public int Part02()
    {
        var total = 0;

        foreach (var item in _input)
        {
            if (IsSafe(item))
            {
                total++;
            }
            else
            {
                if (item.Where((_, i) => IsSafe(item.Where((_, index) => index != i).ToList())).Any())
                {
                    total++;
                }
            }
        }

        return total;

    }

    /// <summary>
    /// Class creator
    /// </summary>
    /// <param name="fileName">File to load</param>
    public Program(string fileName)
    {
        _input = [];
        LoadFile(fileName);
    }

    /// <summary>
    /// Main Thread
    /// </summary>
    private static void Main()
    {
        Program t = new(@"C:\Personal\AdventOfCode\2024\Input\Input.txt");

        Console.WriteLine("First Part: {0}", t.Part01());
        Console.WriteLine("Second Part: {0}", t.Part02());
        Console.ReadLine();
    }

}