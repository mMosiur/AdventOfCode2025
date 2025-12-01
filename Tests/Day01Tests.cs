using AdventOfCode.Year2025.Day01;

namespace AdventOfCode.Year2025.Tests;

[Trait("Year", "2025")]
[Trait("Day", "01")]
[Trait("Day", "1")]
public sealed class Day01Tests : BaseDayTests<Day01Solver, Day01SolverOptions>
{
    protected override string DayInputsDirectory => "Day01";

    protected override Day01Solver CreateSolver(Day01SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "3")]
    [InlineData("my-input.txt", "1066")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);
}
