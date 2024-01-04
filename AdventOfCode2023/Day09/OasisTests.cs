namespace AdventOfCode2023.Day09;

public class OasisTests
{
    [Theory]
    [ClassData(typeof(ParseReadingsTestData))]
    public void ShouldParseReadings(string line, IEnumerable<int> expectedReadings)
    {
        Oasis.ParseReadings(line).Should().BeEquivalentTo(expectedReadings);
    }

    public class ParseReadingsTestData : TheoryData<string, IEnumerable<int>>
    {
        public ParseReadingsTestData()
        {
            Add("0 3 6 9 12 15", [0, 3, 6, 9, 12, 15]);
            Add("1 3 6 10 15 21", [1, 3, 6, 10, 15, 21]);
            Add("10 13 16 21 30 45", [10, 13, 16, 21, 30, 45]);
        }
    }

    [Theory]
    [ClassData(typeof(ReadingDifferencesTestData))]
    public void ShouldReturnReadingDifferences(IEnumerable<int> readings, IEnumerable<int> expectedDifferences)
    {
        Oasis.GetDifferences(readings).Should().BeEquivalentTo(expectedDifferences);
    }

    public class ReadingDifferencesTestData : TheoryData<IEnumerable<int>, IEnumerable<int>>
    {
        public ReadingDifferencesTestData()
        {
            Add([0, 3, 6, 9, 12, 15],
                [3, 3, 3, 3, 3]);
            Add([3, 3, 3, 3, 3],
                [0, 0, 0, 0]);

            Add([1, 3, 6, 10, 15, 21],
                [2, 3, 4, 5, 6]);
            Add([2, 3, 4, 5, 6],
                [1, 1, 1, 1]);
            Add([1, 1, 1, 1],
                [0, 0, 0]);

            Add([10, 13, 16, 21, 30, 45],
                [3, 3, 5, 9, 15]);
            Add([3, 3, 5, 9, 15],
                [0, 2, 4, 6]);
            Add([0, 2, 4, 6],
                [2, 2, 2]);
            Add([2, 2, 2],
                [0, 0]);
        }
    }

    [Theory]
    [ClassData(typeof(PredictNextReadingTestData))]
    public void ShouldPredictNextReading(IEnumerable<int> readings, int expectedNextReading)
    {
        Oasis.PredictNextReading(readings).Should().Be(expectedNextReading);
    }

    public class PredictNextReadingTestData : TheoryData<IEnumerable<int>, int>
    {
        public PredictNextReadingTestData()
        {
            Add([0, 0, 0, 0], 0);
            Add([3, 3, 3, 3, 3], 3);
            Add([0, 3, 6, 9, 12, 15], 18);

            Add([0, 0, 0], 0);
            Add([1, 1, 1, 1], 1);
            Add([2, 3, 4, 5, 6], 7);
            Add([1, 3, 6, 10, 15, 21], 28);

            Add([0, 0], 0);
            Add([2, 2, 2], 2);
            Add([0, 2, 4, 6], 8);
            Add([3, 3, 5, 9, 15], 23);
            Add([10, 13, 16, 21, 30, 45], 68);
        }
    }

    [Fact]
    public void ShouldSumPredictedReadings()
    {
        IEnumerable<string> readingsLines = [
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45"
        ];

        var readings = Oasis.ParseReadings(readingsLines);
        Oasis.SumPredictedReadings(readings).Should().Be(114);
    }
}
