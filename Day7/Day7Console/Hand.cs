using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day7.Day7Console;

public partial class Hand
{
    public Hand(string cards, HandType handType, int bid)
    {
        Cards = cards;
        HandType = handType;
        Bid = bid;
    }

    public string Cards { get; private set; }
    public HandType HandType { get; private set; }
    public int Bid { get; private set; }

    public static IEnumerable<Hand> ParseHands(FileInfo file) =>
        File.ReadLines(file.FullName)
            .Select(ParseHand);

    public static Hand ParseHand(string handText)
    {
        var words = handText.Split(' ');
        var cards = words[0];
        var handType = ParseHandType(words[0]);
        var bid = int.Parse(words[1]);

        return new Hand(cards, handType, bid);
    }

    public static HandType ParseHandType(string handText)
    {
        var orderedHand = new string(handText.OrderDescending().ToArray());

        if (FiveOfAKind().IsMatch(orderedHand))
        {
            return HandType.FiveOfAKind;
        }

        if (FourOfAKind().IsMatch(orderedHand))
        {
            return HandType.FourOfAKind;
        }

        if (FullHouse().IsMatch(orderedHand))
        {
            return HandType.FullHouse;
        }

        if (ThreeOfAKind().IsMatch(orderedHand))
        {
            return HandType.ThreeOfAKind;
        }

        if (TwoPair().IsMatch(orderedHand))
        {
            return HandType.TwoPair;
        }

        if (OnePair().IsMatch(orderedHand))
        {
            return HandType.OnePair;
        }

        return HandType.HighCard;
    }

    [GeneratedRegex(@"(\w)\1\1\1\1")]
    private static partial Regex FiveOfAKind();

    [GeneratedRegex(@"(\w)\1\1\1")]
    private static partial Regex FourOfAKind();

    [GeneratedRegex(@"(\w)\1\1(\w)\2|(\w)\3(\w)\4\4")]
    private static partial Regex FullHouse();

    [GeneratedRegex(@"(\w)\1\1")]
    private static partial Regex ThreeOfAKind();

    [GeneratedRegex(@"(\w)\1\w?(\w)\2")]
    private static partial Regex TwoPair();

    [GeneratedRegex(@"(\w)\1")]
    private static partial Regex OnePair();

    public static IEnumerable<(Hand Hand, int Rank)> Rank(IEnumerable<Hand> hands) =>
        hands
            .Order(new HandComparer())
            .Select((h, i) => (h, i + 1));

    public static long GetWinnings(IEnumerable<Hand> hands) =>
        Rank(hands)
            .Sum(r => r.Hand.Bid * r.Rank);
}

public class HandComparer : IComparer<Hand>
{
    public int Compare(Hand? x, Hand? y)
    {
        if (x is null && y is not null)
        {
            return -1;
        }
        else if (x is not null && y is null)
        {
            return 1;
        }
        else if (x is null && y is null)
        {
            return 0;
        }

        if (x!.HandType < y!.HandType)
        {
            return -1;
        }
        else if (x!.HandType > y!.HandType)
        {
            return 1;
        }

        for (int i = 0; i < x.Cards.Length; i++)
        {
            var leftCard = x.Cards[i].ToCardType();
            var rightCard = y.Cards[i].ToCardType();

            if (leftCard < rightCard)
            {
                return -1;
            }
            else if (leftCard > rightCard)
            {
                return 1;
            }
        }

        return 0;
    }
}

public enum HandType
{
    HighCard = 1,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind
}

public enum CardType
{
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13,
    Ace = 14
}

public static class Extensions
{
    public static CardType ToCardType(this char character) =>
        character switch
        {
            '2' => CardType.Two,
            '3' => CardType.Three,
            '4' => CardType.Four,
            '5' => CardType.Five,
            '6' => CardType.Six,
            '7' => CardType.Seven,
            '8' => CardType.Eight,
            '9' => CardType.Nine,
            'T' => CardType.Ten,
            'J' => CardType.Jack,
            'Q' => CardType.Queen,
            'K' => CardType.King,
            'A' => CardType.Ace,
            _ => throw new ArgumentException($"Character '{character}' is invalid.", nameof(character)),
        };
}
