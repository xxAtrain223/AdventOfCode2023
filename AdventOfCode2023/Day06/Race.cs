namespace AdventOfCode2023.Day06;

public partial class Race
{
    public long MaxTime { get; private set; }
    public long DistanceToBeat { get; private set; }

    public Race(long time, long distance)
    {
        MaxTime = time;
        DistanceToBeat = distance;
    }

    public static IEnumerable<Race> ParseRaces(string raceText)
    {
        var lines = raceText.Split('\n');
        var times = GetLongs(lines[0]);
        var distances = GetLongs(lines[1]);

        for (var i = 0; i < times.Length; i++)
        {
            yield return new Race(times[i], distances[i]);
        }
    }

    private static long[] GetLongs(string line) => NumberRegex()
        .Matches(line)
        .Select(m => long.Parse(m.ValueSpan))
        .ToArray();

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    public IEnumerable<(long Time, long Distance)> GetDistancesForward() =>
        CreateRange(0, MaxTime + 1, 1)
            .Select(CalculateDistance);

    public IEnumerable<(long Time, long Distance)> GetDistancesBackward() =>
        CreateRange(MaxTime, MaxTime, -1)
            .Select(CalculateDistance);

    private (long Time, long Distance) CalculateDistance(long t) =>
        (t, t * (MaxTime - t));

    public static IEnumerable<long> CreateRange(long start, long count, long step = 1)
    {
        var limit = start + count * Math.Sign(step);

        if (step > 0)
        {
            while (start < limit)
            {
                yield return start;
                start += step;
            }
        }
        else
        {
            while (start > limit)
            {
                yield return start;
                start += step;
            }
        }
    }

    public IEnumerable<long> GetWinningTimesForward() =>
        GetDistancesForward()
            .Where(td => td.Distance > DistanceToBeat)
            .Select(td => td.Time);

    public IEnumerable<long> GetWinningTimesBackward() =>
        GetDistancesBackward()
            .Where(td => td.Distance > DistanceToBeat)
            .Select(td => td.Time);

    public static long GetNumberOfWinningCombinations(string raceText) =>
        ParseRaces(raceText)
            .Select(r => r.GetWinningTimesForward().Count())
            .Aggregate((a, b) => a * b);

    public static long GetNumberOfWinningCombinations(FileInfo file) =>
        GetNumberOfWinningCombinations(File.ReadAllText(file.FullName));

    public static long GetNumberOfWinningTimes(FileInfo file) =>
        GetNumberOfWinningTimes(File.ReadAllText(file.FullName));

    public static long GetNumberOfWinningTimes(string raceText)
    {
        var race = ParseSingleRace(raceText);

        var lowerTime = race.GetWinningTimesForward().First();
        var upperTime = race.GetWinningTimesBackward().First();

        return upperTime - lowerTime + 1;
    }

    public static Race ParseSingleRace(string raceText)
    {
        var lines = raceText.Split('\n');
        var time = ParseNumbersAsOneNumber(lines[0]);
        var distance = ParseNumbersAsOneNumber(lines[1]);

        return new Race(time, distance);
    }

    private static long ParseNumbersAsOneNumber(string line) =>
        long.Parse(
            NumberRegex()
                .Match(line.Replace(" ", ""))
                .ValueSpan);
}


