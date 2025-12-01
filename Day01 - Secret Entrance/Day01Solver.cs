using AdventOfCode.Common;
using AdventOfCode.Year2025.Day01.Puzzle;

namespace AdventOfCode.Year2025.Day01;

public sealed class Day01Solver : DaySolver<Day01SolverOptions>
{
    public override int Year => 2025;
    public override int Day => 1;
    public override string Title => "Secret Entrance";

    private readonly IEnumerable<Rotation> _inputData;

    public Day01Solver(Day01SolverOptions options) : base(options)
    {
        _inputData = InputReader.Read(InputLines);
    }

    public Day01Solver(Action<Day01SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day01Solver() : this(new Day01SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var rotator = new DialRotator(Options.DialLowestNumber, Options.DialHighestNumber, Options.DialStartingPosition);
        var result = rotator.CountZeroPositions(_inputData);
        return result.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
