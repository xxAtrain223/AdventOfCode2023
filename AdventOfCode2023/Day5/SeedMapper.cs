namespace AdventOfCode2023.Day5;
public partial class SeedMapper
{
    private readonly Dictionary<string, ValueMapper> _valueMappers;
    private readonly bool _interpretSeedsAsRange;

    public SeedMapper(string mappingsString, bool interpretSeedsAsRange = false)
    {
        _interpretSeedsAsRange = interpretSeedsAsRange;

        var groups = mappingsString
            .Replace("\r", string.Empty)
            .Split("\n\n");

        if (_interpretSeedsAsRange == false)
        {
            _seeds = ParseSeeds(groups[0]).ToArray();
        }
        else
        {
            _seedRanges = ParseSeedRanges(groups[0]).ToArray();
        }

        _valueMappers = groups[1..]
            .Select(g => new ValueMapper(g))
            .ToDictionary(v => v.Source);
    }

    public SeedMapper(FileInfo file, bool interpretSeedsAsRange = false) :
        this(File.ReadAllText(file.FullName), interpretSeedsAsRange)
    {
    }

    public long MapForward(long seedValue, string destination)
    {
        var mapper = _valueMappers["seed"];
        var mappedValue = mapper.MapForward(seedValue);

        while (mapper.Destination != destination)
        {
            mapper = _valueMappers[mapper.Destination];
            mappedValue = mapper.MapForward(mappedValue);
        }

        return mappedValue;
    }

    public IEnumerable<(long RangeStart, long RangeLength)> MapRangesForward(string destination)
    {
        var mapper = _valueMappers["seed"];
        var mappedRanges = mapper.MapRangesForward(_seedRanges).ToArray();

        while (mapper.Destination != destination)
        {
            mapper = _valueMappers[mapper.Destination];
            mappedRanges = mapper.MapRangesForward(mappedRanges).ToArray();
        }

        return mappedRanges;
    }

    private static IEnumerable<long> ParseSeeds(string seedsString)
    {
        if (seedsString.StartsWith("seeds:") == false)
        {
            throw new Exception("String does not start with 'seeds:'");
        }

        var matches = NumberRegex().Matches(seedsString);

        foreach (Match match in matches)
        {
            yield return long.Parse(match.ValueSpan);
        }
    }

    private static IEnumerable<(long SeedStart, long SeedLength)> ParseSeedRanges(string seedsString)
    {
        if (seedsString.StartsWith("seeds:") == false)
        {
            throw new Exception("String does not start with 'seeds:'");
        }

        var matches = NumberPairRegex().Matches(seedsString);

        foreach (Match match in matches)
        {
            yield return (long.Parse(match.Groups[1].ValueSpan), long.Parse(match.Groups[2].ValueSpan));
        }
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();


    [GeneratedRegex(@"(\d+)\s+(\d+)")]
    private static partial Regex NumberPairRegex();

    private long[] _seeds = [];

    private (long SeedStart, long SeedLength)[] _seedRanges = [];

    public IEnumerable<long> Seeds
    { 
        get
        {
            if (_interpretSeedsAsRange)
            {
                foreach (var (seedStart, seedLength) in _seedRanges!)
                {
                    for (int i = 0; i < seedLength; i++)
                    {
                        yield return seedStart + i;
                    }
                }
            }
            else
            {
                foreach (var seed in _seeds!)
                {
                    yield return seed;
                }
            }
        }
    }

    public long FindMinimumLocationForward()
    {
        var chunks = Seeds.Chunk(1_000_000);
        var minimums = new List<long>();

        Parallel.ForEach(chunks, chunk =>
        {
            var minimum = chunk
                .Select(s => MapForward(s, "location"))
                .Min();
            minimums.Add(minimum);
        });

        return minimums.Min();
    }

    public long FindMinimumLocationForwardRange() =>
        MapRangesForward("location").Min(r => r.RangeStart);
}
