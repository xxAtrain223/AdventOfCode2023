namespace AdventOfCode2023.Day2.Day2Tests;

public class GameTests
{
    readonly Bag _bag = new(12, 13, 14);

    [Theory]
    [InlineData("3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
    [InlineData("1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [InlineData("8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
    [InlineData("1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
    [InlineData("6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
    public void ShouldReturnIfGameIsPossible(string game, bool expectedIsValid)
    {
        _bag.IsGamePossible(game).Should().Be(expectedIsValid);
    }

    [Fact]
    public void ShouldReturnSumOfPossibleGameIDs()
    {
        IEnumerable<string> games = [
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        ];

        _bag.SumPossibleGameIDs(games).Should().Be(8);
    }

    [Theory]
    [InlineData("3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 4, 2, 6)]
    [InlineData("1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 1, 3, 4)]
    [InlineData("8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 20, 13, 6)]
    [InlineData("1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 14, 3, 15)]
    [InlineData("6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 6, 3, 2)]
    public void ShouldReturnMaxColorCounts(string game, int expectedRedCount, int expectedGreenCount, int expectedBlueCount)
    {
        var (redCount, greenCount, blueCount) = Bag.GetMaxColorCounts(game);

        redCount.Should().Be(expectedRedCount);
        greenCount.Should().Be(expectedGreenCount);
        blueCount.Should().Be(expectedBlueCount);
    }

    [Theory]
    [InlineData("3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
    [InlineData("1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
    [InlineData("8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
    [InlineData("1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
    [InlineData("6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
    public void ShouldReturnGamePower(string game, int expectedPower)
    {
        var gamePower = Bag.GetGamePower(game);

        gamePower.Should().Be(expectedPower);
    }

    [Fact]
    public void ShouldReturnSumOfGamePowers()
    {
        IEnumerable<string> games = [
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        ];

        Bag.SumGamePowers(games).Should().Be(2286);
    }
}
