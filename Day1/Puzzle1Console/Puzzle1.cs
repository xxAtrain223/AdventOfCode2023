using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day1.Puzzle1Console;

public static partial class Puzzle1
{
    public static int GetCalibrationValue(string line)
    {
        var match = GetNumbersRegex().Match(line);

        if (match.Success == false)
        {
            throw new Exception($"The GetNumbersRegex did not match the line '{line}'.");
        }

        var firstNumberSpan = match.Groups[1].ValueSpan;
        var lastNumberSpan = match.Groups[2].ValueSpan;

        if (lastNumberSpan.IsEmpty == false)
        {
            return int.Parse(string.Concat(firstNumberSpan, lastNumberSpan));
        }
        else
        {
            return int.Parse(string.Concat(firstNumberSpan, firstNumberSpan));
        }
    }

    [GeneratedRegex(@"^\D*?(\d).*?(\d?)\D*?$")]
    private static partial Regex GetNumbersRegex();
}
