namespace AdventOfCode2023.Day06;

public class Day6Tests(ITestOutputHelper Output)
{
    [Fact]
    public void Part1()
    {
        var winningCombinationCount = Race.GetNumberOfWinningCombinations(Input);
        Output.WriteLine(winningCombinationCount.ToString());
    }

    [Fact]
    public void Part2()
    {
        var winningTimesCount = Race.GetNumberOfWinningTimes(Input);
        Output.WriteLine(winningTimesCount.ToString());
    }

    private static string Input => """
        Time:        41     66     72     66
        Distance:   244   1047   1228   1040
        """;

    private static IEnumerable<string> InputLines => Input.SplitByLine();
}
