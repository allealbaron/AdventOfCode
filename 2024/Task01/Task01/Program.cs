using System.Text;

namespace Task01;

public class Program
{

    private readonly List<int> _leftList;
    private readonly List<int> _rightList;

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
            var splitValues = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _leftList.Add(int.Parse(splitValues[0]));
            _rightList.Add(int.Parse(splitValues[1]));
        }

        _leftList.Sort();
        _rightList.Sort();

    }

    public int CalculateTotalDistance()
    {
        return _leftList.Select((t, i) => Math.Abs(t - _rightList[i])).Sum();
    }

    public List<(T Value, int Amount)> CountOccurrences<T>(List<T> input)
    {

        return input
            .GroupBy(x => x)
            .Select(g => (Value: g.Key, Amount: g.Count()))
            .ToList();
    }

    public int CalculateSimilarity()
    {

        var rightCounts = CountOccurrences(_rightList)
            .ToDictionary(x => x.Value, x => x.Amount);

        return CountOccurrences(_leftList)
            .Where(itemLeft => rightCounts.ContainsKey(itemLeft.Value))
            .Sum(itemLeft => itemLeft.Amount * itemLeft.Value * rightCounts[itemLeft.Value]);

    }

    /// <summary>
    /// Class creator
    /// </summary>
    /// <param name="fileName">File to load</param>
    public Program(string fileName)
    {

        _leftList = [];
        _rightList = [];
        LoadFile(fileName);
    }

    /// <summary>
    /// Main Thread
    /// </summary>
    private static void Main()
    {
        Program t = new(@"C:\Personal\AdventOfCode\2024\Input\Input.txt");

        Console.WriteLine("First Part: {0}", t.CalculateTotalDistance());
        Console.WriteLine("Second Part: {0}", t.CalculateSimilarity());
        Console.ReadLine();
    }

}