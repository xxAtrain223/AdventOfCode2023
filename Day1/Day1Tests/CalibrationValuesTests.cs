namespace AdventOfCode2023.Day1.Day1Tests;

public partial class CalibrationValuesTests
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void ShouldGetCalibrationValueFromLine(string line, int number)
    {
        CalibrationValues.GetCalibrationValue(line).Should().Be(number);
    }

    [Fact]
    public void ShouldGetCalibrationValueFromIEnumerable()
    {
        IEnumerable<string> lines = [
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet",
        ];

        CalibrationValues.GetCalibrationValue(lines).Should().Be(142);
    }

    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void ShouldGetCalibrationValueFromLineWithSpelledOutNumbers(string line, int number)
    {
        CalibrationValues.GetCalibrationValue(line).Should().Be(number);
    }

    [Fact]
    public void ShouldGetCalibrationValueFromIEnumerableWithSpelledOutNumbers()
    {
        IEnumerable<string> lines = [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        ];

        CalibrationValues.GetCalibrationValue(lines).Should().Be(281);
    }
}
