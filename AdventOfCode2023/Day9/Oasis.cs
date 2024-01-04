
namespace AdventOfCode2023.Day9;

public class Oasis
{
    public static IEnumerable<IEnumerable<int>> ParseReadings(IEnumerable<string> lines) =>
        lines.Select(ParseReadings);

    public static IEnumerable<int> ParseReadings(string line) =>
        line.Split(' ').Select(int.Parse);

    public static IEnumerable<int> GetDifferences(IEnumerable<int> readings) =>
        readings.SelectWithPrevious((prev, curr) => curr - prev);

    public static int PredictNextReading(IEnumerable<int> readings)
    {
        if (readings.All(r => r == 0))
        {
            return 0;
        }

        var predictedDifference = PredictNextReading(GetDifferences(readings));
        return readings.Last() + predictedDifference;
    }

    public static int SumPredictedReadings(IEnumerable<IEnumerable<int>> readings) =>
        readings.Sum(PredictNextReading);
}
