using AdventOfCode.Common;

namespace AdventOfCode.Year2025.Day01;

public sealed class Day01SolverOptions : DaySolverOptions
{
    public int DialLowestNumber { get; set; } = 0;
    public int DialHighestNumber { get; set; } = 99;
    public int DialStartingPosition { get; set; } = 50;
}
