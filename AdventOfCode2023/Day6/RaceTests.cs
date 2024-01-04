namespace AdventOfCode2023.Day6;

public class RaceTests
{
    [Fact]
    public void ShouldCreate3Races()
    {
        var races = Race.ParseRaces("""
            Time:      7  15   30
            Distance:  9  40  200
            """);

        races.Should().BeEquivalentTo([
            new Race(7, 9),
            new Race(15, 40),
            new Race(30, 200)
        ]);
    }

    [Fact]
    public void ShouldReturnRace1Distances()
    {
        new Race(7, 9).GetDistancesForward().Should().BeEquivalentTo([
            (0, 0),
            (1, 6),
            (2, 10),
            (3, 12),
            (4, 12),
            (5, 10),
            (6, 6),
            (7, 0)
        ]);
    }

    [Fact]
    public void ShouldReturnRace1WinningTimes()
    {
        new Race(7, 9).GetWinningTimesForward().Should().BeEquivalentTo([
            2,
            3,
            4,
            5
        ]);
    }

    [Fact]
    public void ShouldReturnNumberOfWinningCombinations()
    {
        Race.GetNumberOfWinningCombinations("""
            Time:      7  15   30
            Distance:  9  40  200
            """).Should().Be(288);
    }
}
