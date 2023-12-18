using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day5.Day5Console;

public partial class ValueMapper
{
    public ValueMapper(string mapString)
    {
        var lines = mapString.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length < 2)
        {
            throw new ArgumentException("Must contain at least 1 line.", nameof(mapString));
        }

        (Source, Destination) = ParseHeader(lines[0]);
        _valueMap = lines[1..]
            .SelectMany(ParseRange)
            .ToDictionary(
                r => r.SourceValue,
                r => r.DestinationValue);
    }

    public string Source { get; private set; }

    public string Destination { get; private set; }

    private static (string Source, string Destination) ParseHeader(string headerString)
    {
        var match = HeaderRegex().Match(headerString);

        if (match.Success == false)
        {
            throw new Exception("Unable to parse header.");
        }

        return (match.Groups[1].Value, match.Groups[2].Value);
    }

    [GeneratedRegex(@"(\w+)-to-(\w+) map:")]
    private static partial Regex HeaderRegex();

    private IDictionary<long, long> _valueMap;

    private static IEnumerable<(long SourceValue, long DestinationValue)> ParseRange(string rangeString)
    {
        var match = RangeRegex().Match(rangeString);

        if (match.Success == false)
        {
            throw new Exception("Unable to parse range.");
        }

        var destinationStart = long.Parse(match.Groups[1].ValueSpan);
        var sourceStart = long.Parse(match.Groups[2].ValueSpan);
        var length = long.Parse(match.Groups[3].ValueSpan);

        for (int i = 0; i < length; i++)
        {
            yield return (sourceStart + i, destinationStart + i);
        }
    }

    [GeneratedRegex(@"(\d+)\s+(\d+)\s+(\d+)")]
    private static partial Regex RangeRegex();

    public long Map(long sourceValue) =>
        _valueMap.TryGetValue(sourceValue, out var destinationValue) ?
        destinationValue :
        sourceValue;

    public long this[long sourceValue] => Map(sourceValue);
}
