using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day5.Day5Console;
public partial class SeedMapper
{
    private readonly Dictionary<string, ValueMapper> _valueMappers;

    public SeedMapper(string mappingsString)
    {
        var groups = mappingsString
            .Replace("\r", string.Empty)
            .Split("\n\n");

        Seeds = ParseSeeds(groups[0]).ToArray();

        _valueMappers = groups[1..]
            .Select(g => new ValueMapper(g))
            .ToDictionary(v => v.Source);
    }

    public SeedMapper(FileInfo file) : this(File.ReadAllText(file.FullName))
    {
    }

    public long MapTo(long seedValue, string destination)
    {
        var mapper = _valueMappers["seed"];
        var mappedValue = mapper.Map(seedValue);

        while (mapper.Destination != destination)
        {
            mapper = _valueMappers[mapper.Destination];
            mappedValue = mapper.Map(mappedValue);
        }

        return mappedValue;
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

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    public long[] Seeds { get; private set; }

    public long FindMinimumLocation() => Seeds
        .Select(s => MapTo(s, "location"))
        .Min();
}
