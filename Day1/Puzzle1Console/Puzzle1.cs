using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day1.Puzzle1Console;

public static partial class Puzzle1
{
    public static int GetCalibrationValue(string line)
    {
        var firstNumberMatch = FirstNumberRegex().Match(line);

        if (firstNumberMatch.Success == false)
        {
            throw new Exception($"The FirstNumberRegex did not match the line '{line}'.");
        }

        var lastNumberMatch = LastNumberRegex().Match(line);

        if (lastNumberMatch.Success == false)
        {
            throw new Exception($"The LastNumberRegex did not match the line '{line}'.");
        }

        var firstNumber = ParseNumber(firstNumberMatch.Groups[1].ValueSpan);
        var lastNumber = ParseNumber(lastNumberMatch.Groups[1].ValueSpan);

        return firstNumber * 10 + lastNumber;
    }

    private static int ParseNumber(ReadOnlySpan<char> numberSpan) =>
        int.TryParse(numberSpan, out var parsedNumber) ?
        parsedNumber : ParseSpelledOutInt(numberSpan);

    private static int ParseSpelledOutInt(ReadOnlySpan<char> numberSpan) => numberSpan switch
    {
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        _ => throw new Exception($"Unknown number '{numberSpan}'")
    };

    public static int GetCalibrationValue(IEnumerable<string> lines) =>
        lines.Sum(GetCalibrationValue);

    public static int GetCalibrationValue(FileInfo file) =>
        GetCalibrationValue(File.ReadLines(file.FullName));

    [GeneratedRegex(@"(\d|one|two|three|four|five|six|seven|eight|nine)")]
    private static partial Regex FirstNumberRegex();

    [GeneratedRegex(@"(\d|one|two|three|four|five|six|seven|eight|nine)", RegexOptions.RightToLeft)]
    private static partial Regex LastNumberRegex();
}
