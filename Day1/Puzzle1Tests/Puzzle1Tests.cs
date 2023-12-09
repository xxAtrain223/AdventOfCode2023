namespace AdventOfCode2023.Day1.Puzzle1Tests;

public partial class Puzzle1Tests
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void ShouldGetCalibrationValueFromLine(string line, int number)
    {
        Puzzle1.GetCalibrationValue(line).Should().Be(number);
    }
}
