namespace AdventOfCode.Year2025.Day01.Puzzle;

internal sealed class DialRotator
{
    private readonly int _dialLowestNumber;
    private readonly int _dialHighestNumber;
    private readonly int _dialStartingPosition;
    private readonly int _dialRangeSize;

    public DialRotator(int dialLowestNumber, int dialHighestNumber, int dialStartingPosition)
    {
        if (dialLowestNumber >= dialHighestNumber)
        {
            throw new ArgumentException("Dial lowest number must be less than highest number.");
        }

        _dialLowestNumber = dialLowestNumber;
        _dialHighestNumber = dialHighestNumber;
        _dialStartingPosition = dialStartingPosition;
        _dialRangeSize = _dialHighestNumber - _dialLowestNumber + 1;
    }

    public int CountZeroPositions(IEnumerable<Rotation> rotations)
    {
        int currentPosition = _dialStartingPosition;
        int zeroPositionCount = currentPosition == 0 ? 1 : 0;

        foreach (var rotation in rotations)
        {
            currentPosition = Rotate(currentPosition, rotation);

            if (currentPosition == 0)
            {
                zeroPositionCount++;
            }
        }

        return zeroPositionCount;
    }

    private int Rotate(int currentPosition, Rotation rotation)
    {
        int newPosition = rotation.Direction switch
        {
            RotationDirection.Left => currentPosition - (rotation.Distance % _dialRangeSize),
            RotationDirection.Right => currentPosition + (rotation.Distance % _dialRangeSize),
            _ => throw new InvalidOperationException("Unknown rotation direction.")
        };

        // Wrap around the dial range
        newPosition = ((newPosition + _dialRangeSize) % _dialRangeSize);

        return newPosition;
    }
}

internal readonly record struct Rotation(RotationDirection Direction, int Distance)
{
    public static Rotation Parse(ReadOnlySpan<char> s)
    {
        try
        {
            return ParseInternal(s.Trim());
        }
        catch (Exception ex)
        {
            throw new FormatException($"Invalid rotation format: '{s.ToString()}'", ex);
        }
    }

    private static Rotation ParseInternal(ReadOnlySpan<char> s)
    {
        if (s.Length < 2)
        {
            throw new FormatException("Rotation string too short.");
        }

        return new(
            Direction: s[0] switch
            {
                'L' or 'l' => RotationDirection.Left,
                'R' or 'r' => RotationDirection.Right,
                _ => throw new FormatException($"Invalid rotation direction: '{s[0]}'")
            },
            Distance: int.Parse(s[1..].ToString())
        );
    }
}

internal enum RotationDirection
{
    /// <summary>
    /// Rotation towards smaller number
    /// </summary>
    Left = 1,

    /// <summary>
    /// Rotation towards larger number
    /// </summary>
    Right = 2,
}
