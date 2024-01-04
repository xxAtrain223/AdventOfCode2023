namespace AdventOfCode2023.Day04;

public class CardTests
{
    [Theory]
    [ClassData(typeof(CardNumberTestData))]
    public void CardNumber(string cardText, int expectedCardNumber)
    {
        var card = new Card(cardText);

        card.CardNumber.Should().Be(expectedCardNumber);
    }

    [Theory]
    [ClassData(typeof(WinningNumbersTestData))]
    public void WinningNumbers(string cardText, int[] expectedWinningNumbers)
    {
        var card = new Card(cardText);

        card.WinningNumbers.Should().BeEquivalentTo(expectedWinningNumbers);
    }

    [Theory]
    [ClassData(typeof(MyNumbersTestData))]
    public void MyNumbers(string cardText, int[] expectedMyNumbers)
    {
        var card = new Card(cardText);

        card.MyNumbers.Should().BeEquivalentTo(expectedMyNumbers);
    }

    [Theory]
    [ClassData(typeof(MatchedNumbersTestData))]
    public void MatchedNumbers(string cardText, int[] expectedMatchedNumbers)
    {
        var card = new Card(cardText);

        card.GetMatchedNumbers().Should().BeEquivalentTo(expectedMatchedNumbers);
    }

    [Theory]
    [ClassData(typeof(ScoreTestData))]
    public void Score(string cardText, int expectedScore)
    {
        var card = new Card(cardText);

        card.GetScore().Should().Be(expectedScore);
    }

    [Fact]
    public void SumCardScores()
    {
        var sumOfCardScores = Card.SumCardScores([
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
        ]);

        sumOfCardScores.Should().Be(13);
    }

    [Fact]
    public void CountCards()
    {
        var sumOfCardScores = Card.Count([
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
        ]);

        sumOfCardScores.Should().Be(30);
    }

    public class CardNumberTestData : TheoryData<string, int>
    {
        public CardNumberTestData()
        {
            Add("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 1);
            Add("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2);
            Add("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 3);
            Add("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 4);
            Add("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 5);
            Add("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 6);
        }
    }

    public class WinningNumbersTestData : TheoryData<string, int[]>
    {
        public WinningNumbersTestData()
        {
            Add("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", [41, 48, 83, 86, 17]);
            Add("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", [13, 32, 20, 16, 61]);
            Add("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", [1, 21, 53, 59, 44]);
            Add("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", [41, 92, 73, 84, 69]);
            Add("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", [87, 83, 26, 28, 32]);
            Add("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", [31, 18, 13, 56, 72]);
        }
    }

    public class MyNumbersTestData : TheoryData<string, int[]>
    {
        public MyNumbersTestData()
        {
            Add("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", [83, 86, 6, 31, 17, 9, 48, 53]);
            Add("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", [61, 30, 68, 82, 17, 32, 24, 19]);
            Add("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", [69, 82, 63, 72, 16, 21, 14, 1]);
            Add("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", [59, 84, 76, 51, 58, 5, 54, 83]);
            Add("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", [88, 30, 70, 12, 93, 22, 82, 36]);
            Add("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", [74, 77, 10, 23, 35, 67, 36, 11]);
        }
    }

    public class MatchedNumbersTestData : TheoryData<string, int[]>
    {
        public MatchedNumbersTestData()
        {
            Add("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", [48, 83, 17, 86]);
            Add("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", [32, 61]);
            Add("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", [1, 21]);
            Add("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", [84]);
            Add("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", []);
            Add("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", []);
        }
    }

    public class ScoreTestData : TheoryData<string, int>
    {
        public ScoreTestData()
        {
            Add("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8);
            Add("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2);
            Add("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2);
            Add("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1);
            Add("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0);
            Add("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0);
        }
    }
}
