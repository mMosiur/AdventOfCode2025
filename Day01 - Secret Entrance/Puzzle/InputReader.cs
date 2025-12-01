namespace AdventOfCode.Year2025.Day01.Puzzle;

internal sealed class InputReader
{
    public static IEnumerable<Rotation> Read(IEnumerable<string> inputLines)
    {
        return inputLines
            .Select(ReadLine)
            .ToArray();
    }

    private static Rotation ReadLine(string line)
    {
        return Rotation.Parse(line);
    }
}
