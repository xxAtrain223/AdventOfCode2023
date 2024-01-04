namespace AdventOfCode2023.Day5;

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
        _valueMaps = lines[1..]
            .Select(ParseRange)
            .OrderBy(r => r.SourceStart)
            .ToArray();
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

    private (long SourceStart, long DestinationStart, long Length)[] _valueMaps;

    private static (long SourceStart, long DestinationStart, long Length) ParseRange(string rangeString)
    {
        var match = RangeRegex().Match(rangeString);

        if (match.Success == false)
        {
            throw new Exception("Unable to parse range.");
        }

        var destinationStart = long.Parse(match.Groups[1].ValueSpan);
        var sourceStart = long.Parse(match.Groups[2].ValueSpan);
        var length = long.Parse(match.Groups[3].ValueSpan);

        return (sourceStart, destinationStart, length);
    }

    [GeneratedRegex(@"(\d+)\s+(\d+)\s+(\d+)")]
    private static partial Regex RangeRegex();

    public long MapForward(long sourceValue)
    {
        foreach (var (sourceStart, destinationStart, length) in _valueMaps)
        {
            if (sourceValue >= sourceStart && sourceValue < (sourceStart + length))
            {
                return destinationStart + (sourceValue - sourceStart);
            }
        }

        return sourceValue;
    }

    public IEnumerable<(long RangeStart, long RangeLength)> MapRangesForward(IEnumerable<(long RangeStart, long RangeLength)> ranges)
    {
        foreach (var range in ranges.OrderBy(r => r.RangeStart))
        {
            var start = range.RangeStart;
            var length = range.RangeLength;

            foreach (var (sourceStart, destinationStart, mapLength) in _valueMaps)
            {
                if (length < 0)
                {
                    throw new Exception("Went below 0.");
                }
                if (length == 0)
                {
                    break;
                }

                long usedLength = 0;

                if (start < sourceStart)
                {
                    var availableLength = sourceStart - start;
                    usedLength = length < availableLength ? length : availableLength;
                    
                    yield return (start, usedLength);

                    length -= usedLength;
                    start += usedLength;

                    if (length == 0)
                    {
                        break;
                    }
                }

                if (start < sourceStart + mapLength)
                {
                    var availableLength = mapLength - (start - sourceStart);
                    usedLength = length < availableLength ? length : availableLength;

                    yield return (destinationStart + (start - sourceStart), usedLength);

                    length -= usedLength;
                    start += usedLength;
                }
            }

            if (length > 0)
            {
                yield return (start, length);
            }
        }
    }

    public long MapBackward(long destinationValue)
    {
        foreach (var (sourceStart, destinationStart, length) in _valueMaps)
        {
            if (destinationValue >= destinationStart && destinationValue < (destinationStart + length))
            {
                return sourceStart + (destinationValue - destinationStart);
            }
        }

        return destinationValue;
    }
}
