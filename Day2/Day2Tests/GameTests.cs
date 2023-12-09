using System.Text.RegularExpressions;

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
}

public partial record Bag(int RedCount, int GreenCount, int BlueCount)
{
    public int SumPossibleGameIDs(IEnumerable<string> games) => games
        .Select(g =>
        {
            var gameMatch = GameRegex().Match(g);

            if (gameMatch.Success == false)
            {
                throw new Exception($"The GameRegex did not match the line '{g}'.");
            }

            return new
            {
                GameID = int.Parse(gameMatch.Groups[1].ValueSpan),
                IsPossible = IsGamePossible(gameMatch.Groups[2].Value)
            };
        })
        .Where(g => g.IsPossible == true)
        .Sum(g => g.GameID);

    public bool IsGamePossible(string game)
    {
        var handfuls = game.Split("; ").Select(ParseHandful);

        foreach (var (redCount, greenCount, blueCount) in handfuls)
        {
            if (redCount > RedCount ||
                greenCount > GreenCount ||
                blueCount > BlueCount)
            {
                return false;
            }
        }

        return true;
    }

    private (int redCount, int greenCount, int blueCount) ParseHandful(string handful)
    {
        var matches = ColorCountRegex().Matches(handful);

        int redCount = 0;
        int greenCount = 0;
        int blueCount = 0;

        foreach (Match match in matches)
        {
            var (count, color) = ParseColorCount(match);
            switch (color)
            {
                case "red":
                    redCount = count;
                    break;
                case "green":
                    greenCount = count;
                    break;
                case "blue":
                    blueCount = count;
                    break;
            }
        }

        return (redCount, greenCount, blueCount);
    }

    private (int count, string color) ParseColorCount(Match match)
    {
        return (int.Parse(match.Groups[1].ValueSpan), match.Groups[2].Value);
    }

    [GeneratedRegex(@"(\d+)\s+(\w+)")]
    private static partial Regex ColorCountRegex();

    [GeneratedRegex(@"Game (\d+): (.*)")]
    private static partial Regex GameRegex();
}
