﻿using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day4.Day4Console;

public partial class Card
{
    private int _cardNumber;
    private int[] _winningNumbers;
    private int[] _myNumbers;

    public Card(string cardText)
    {
        var match = CardPartsRegex().Match(cardText);

        if (match.Success == false)
        {
            throw new Exception($"The CardPartsRegex did not match the card '{cardText}'");
        }

        _cardNumber = ParseCardNumber(match.Groups[1].Value);
        _winningNumbers = ParseNumbers(match.Groups[2].Value);
        _myNumbers = ParseNumbers(match.Groups[3].Value);
    }

    [GeneratedRegex(@"Card\s+(\d+):(.*)\|(.*)")]
    private static partial Regex CardPartsRegex();

    private int ParseCardNumber(string cardText)
    {
        return int.Parse(cardText);
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    private int[] ParseNumbers(string cardText)
    {
        var matches = NumberRegex().Matches(cardText);

        var numbers = new int[matches.Count];

        for (int i = 0; i < matches.Count; i++)
        {
            numbers[i] = int.Parse(matches[i].ValueSpan);
        }

        return numbers;
    }

    public int CardNumber => _cardNumber;

    public int[] WinningNumbers => _winningNumbers;

    public int[] MyNumbers => _myNumbers;

    public IEnumerable<int> GetMatchedNumbers() => _myNumbers.Intersect(_winningNumbers);

    public int GetScore()
    {
        var matchedNumbersCount = GetMatchedNumbers().Count();

        if (matchedNumbersCount == 0)
        {
            return 0;
        }

        return 1 << (matchedNumbersCount - 1);
    }

    public static int SumCardScores(IEnumerable<string> cardTexts) => cardTexts
        .Sum(t => new Card(t).GetScore());

    public static int SumCardScores(FileInfo file) =>
        SumCardScores(File.ReadLines(file.FullName));
}
