﻿using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day2.Day2Console;

public partial record Bag(int RedCount, int GreenCount, int BlueCount)
{
    public int SumPossibleGameIDs(FileInfo file) =>
        SumPossibleGameIDs(File.ReadLines(file.FullName));

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