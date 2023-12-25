using FluentAssertions;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day7.Day7Tests;

public class HandTests
{
    [Theory]
    [InlineData("AAAAA", HandType.FiveOfAKind)]
    [InlineData("77777", HandType.FiveOfAKind)]
    [InlineData("AA8AA", HandType.FourOfAKind)]
    [InlineData("77877", HandType.FourOfAKind)]
    [InlineData("23332", HandType.FullHouse)]
    [InlineData("32223", HandType.FullHouse)]
    [InlineData("TTT98", HandType.ThreeOfAKind)]
    [InlineData("77798", HandType.ThreeOfAKind)]
    [InlineData("23432", HandType.TwoPair)]
    [InlineData("24432", HandType.TwoPair)]
    [InlineData("A23A4", HandType.OnePair)]
    [InlineData("223A4", HandType.OnePair)]
    [InlineData("23456", HandType.HighCard)]
    [InlineData("A3456", HandType.HighCard)]
    public void ShouldReturnHandType(string handText, HandType expectedHandType)
    {
        Hand.ParseHandType(handText).Should().Be(expectedHandType);
    }

    [Theory]
    [InlineData('2', CardType.Two, 2)]
    [InlineData('3', CardType.Three, 3)]
    [InlineData('4', CardType.Four, 4)]
    [InlineData('5', CardType.Five, 5)]
    [InlineData('6', CardType.Six, 6)]
    [InlineData('7', CardType.Seven, 7)]
    [InlineData('8', CardType.Eight, 8)]
    [InlineData('9', CardType.Nine, 9)]
    [InlineData('T', CardType.Ten, 10)]
    [InlineData('J', CardType.Jack, 11)]
    [InlineData('Q', CardType.Queen, 12)]
    [InlineData('K', CardType.King, 13)]
    [InlineData('A', CardType.Ace, 14)]
    public void ShouldReturnCardType(char character, CardType expectedCardType, int expectedCardValue)
    {
        var actualCardType = character.ToCardType();

        actualCardType.Should().Be(expectedCardType);
        ((int)actualCardType).Should().Be(expectedCardValue);
    }

    [Theory]
    [ClassData(typeof(ParseHandTestData))]
    public void ShouldParseHand(string handText, Hand expectedHand)
    {
        Hand.ParseHand(handText).Should().BeEquivalentTo(expectedHand);
    }

    public class ParseHandTestData : TheoryData<string, Hand>
    {
        public ParseHandTestData()
        {
            Add("32T3K 765", new Hand("32T3K", HandType.OnePair, 765));
            Add("T55J5 684", new Hand("T55J5", HandType.ThreeOfAKind, 684));
            Add("KK677 28", new Hand("KK677", HandType.TwoPair, 28));
            Add("KTJJT 220", new Hand("KTJJT", HandType.TwoPair, 220));
            Add("QQQJA 483", new Hand("QQQJA", HandType.ThreeOfAKind, 483));
        }
    }


    [Fact]
    public void ShouldOrderHands()
    {
        IEnumerable<Hand> hands = [
            new Hand("32T3K", HandType.OnePair, 765),
            new Hand("T55J5", HandType.ThreeOfAKind, 684),
            new Hand("KK677", HandType.TwoPair, 28),
            new Hand("KTJJT", HandType.TwoPair, 220),
            new Hand("QQQJA", HandType.ThreeOfAKind, 483)
        ];

        Hand.Rank(hands).Should().BeEquivalentTo([
            (new Hand("32T3K", HandType.OnePair, 765), 1),
            (new Hand("KTJJT", HandType.TwoPair, 220), 2),
            (new Hand("KK677", HandType.TwoPair, 28), 3),
            (new Hand("T55J5", HandType.ThreeOfAKind, 684), 4),
            (new Hand("QQQJA", HandType.ThreeOfAKind, 483), 5),
        ], options => options.WithStrictOrdering());
    }

    [Fact]
    public void ShouldReturnWinnings()
    {
        IEnumerable<Hand> hands = [
            new Hand("32T3K", HandType.OnePair, 765),
            new Hand("T55J5", HandType.ThreeOfAKind, 684),
            new Hand("KK677", HandType.TwoPair, 28),
            new Hand("KTJJT", HandType.TwoPair, 220),
            new Hand("QQQJA", HandType.ThreeOfAKind, 483)
        ];

        Hand.GetWinnings(hands).Should().Be(6440);
    }
}

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
