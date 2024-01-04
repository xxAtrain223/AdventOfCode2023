namespace AdventOfCode2023.Day7;

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
    [InlineData('2', CardType.Two, 2, 1)]
    [InlineData('3', CardType.Three, 3, 1)]
    [InlineData('4', CardType.Four, 4, 1)]
    [InlineData('5', CardType.Five, 5, 1)]
    [InlineData('6', CardType.Six, 6, 1)]
    [InlineData('7', CardType.Seven, 7, 1)]
    [InlineData('8', CardType.Eight, 8, 1)]
    [InlineData('9', CardType.Nine, 9, 1)]
    [InlineData('T', CardType.Ten, 10, 1)]
    [InlineData('J', CardType.Jack, 11, 1)]
    [InlineData('Q', CardType.Queen, 12, 1)]
    [InlineData('K', CardType.King, 13, 1)]
    [InlineData('A', CardType.Ace, 14, 1)]
    [InlineData('J', CardType.Joker, 1, 2)]
    public void ShouldReturnCardType(char character, CardType expectedCardType, int expectedCardValue, int part)
    {
        var actualCardType = Hand.ToCardType(character, part);

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

    [Theory]
    [ClassData(typeof(ParseHandPartTwoTestData))]
    public void ShouldParseHandPartTwo(string handText, Hand expectedHand)
    {
        var actualHand = Hand.ParseHand(handText, 2);
        actualHand.Should().BeEquivalentTo(expectedHand);
    }

    public class ParseHandPartTwoTestData : TheoryData<string, Hand>
    {
        public ParseHandPartTwoTestData()
        {
            Add("32T3K 765", new Hand("32T3K", HandType.OnePair, 765, 2));
            Add("T55J5 684", new Hand("T55J5", HandType.FourOfAKind, 684, 2));
            Add("KK677 28", new Hand("KK677", HandType.TwoPair, 28, 2));
            Add("KTJJT 220", new Hand("KTJJT", HandType.FourOfAKind, 220, 2));
            Add("QQQJA 483", new Hand("QQQJA", HandType.FourOfAKind, 483, 2));
        }
    }

    [Fact]
    public void ShouldReturnWinningsPartTwo()
    {
        var hands = Hand.ParseHands([
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483",
        ], 2);

        Hand.GetWinnings(hands).Should().Be(5905);
    }
}
