namespace AdventOfCode2023.Day4;

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

    private int _matchedNumberCount = -1;
    public int MatchedNumberCount
    {
        get
        {
            if (_matchedNumberCount != -1)
            {
                return _matchedNumberCount;
            }

            _matchedNumberCount = GetMatchedNumbers().Count();
            return _matchedNumberCount;
        }
    }


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

    public static int Count(IEnumerable<string> cardTexts)
    {
        var cards = cardTexts
            .Select(t => new Card(t))
            .ToDictionary(c => c.CardNumber);

        var queue = new List<int>(cards.Values.Select(c => c.CardNumber));
        for (int i = 0; i < queue.Count; i++)
        {
            var card = cards[queue[i]];
            queue.AddRange(Enumerable.Range(
                card.CardNumber + 1,
                card.MatchedNumberCount));
        }

        return queue.Count;
    }

    public static int Count(FileInfo file) =>
        Count(File.ReadLines(file.FullName));
}
