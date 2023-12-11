namespace Day3Tests;

public class SchematicTests
{
    private readonly Schematic _schematic = new();

    [Theory]
    [ClassData(typeof(MapSchematicPartNumbersTestData))]
    public void MapLine_ShouldMapSchematicPartNumbers(string line, IEnumerable<Part> expectedMappedParts)
    {
        _schematic.MapLine(line);

        _schematic.MappedParts.Should().BeEquivalentTo(expectedMappedParts);
    }

    [Theory]
    [ClassData(typeof(MapSchematicSymbolsTestData))]
    public void MapLine_ShouldMapSchematicSymbols(string line, IEnumerable<SymbolLocation> expectedMappedSymbols)
    {
        _schematic.MapLine(line);

        _schematic.MappedSymbols.Should().BeEquivalentTo(expectedMappedSymbols);
    }

    [Theory]
    [InlineData("467..114..", 0, 0, 467)]
    [InlineData("467..114..", 0, 1, 467)]
    [InlineData("467..114..", 0, 2, 467)]
    [InlineData("467..114..", 0, 3, 0)]
    [InlineData("467..114..", 0, 4, 0)]
    [InlineData("467..114..", 0, 5, 114)]
    [InlineData("467..114..", 0, 6, 114)]
    [InlineData("467..114..", 0, 7, 114)]
    [InlineData("467..114..", 0, 8, 0)]
    [InlineData("467..114..", 0, 9, 0)]
    [InlineData("467..114..", -1, 0, 0)]
    [InlineData("467..114..", 0, -1, 0)]
    [InlineData("467..114..", 1, 0, 0)]
    [InlineData("467..114..", 0, 10, 0)]
    public void GetPartNumberAtLocation_ShouldReturnPartNumberOrZero(string line, int row, int column, int expectedPartNumber)
    {
        _schematic.MapLine(line);
        _schematic.FinalizeMapping();

        _schematic.GetPartNumberAtLocation(row, column).Should().Be(expectedPartNumber);
    }

    [Fact]
    public void GetPartNumbersAroundLocation_ShouldReturnThreeNumbers()
    {
        _schematic.MapLines("""
            467..114..
            ...*......
            ..35..633.
            """);
        _schematic.FinalizeMapping();

        _schematic.GetPartNumbersAroundLocation(1, 3).Should().BeEquivalentTo([467, 35, 35]);
    }

    [Fact]
    public void GetPartNumbersAroundSymbols_ShouldReturnAllValidNumbers()
    {
        _schematic.MapLines("""
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
            """);
        _schematic.FinalizeMapping();

        _schematic.GetPartNumbersAroundSymbols().Should().BeEquivalentTo([467, 35, 633, 617, 592, 755, 664, 598]);
    }

    [Fact]
    public void SumAllPartNumbersAroundSymbols_ShouldReturn4361()
    {
        _schematic.MapLines("""
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
            """);
        _schematic.FinalizeMapping();

        _schematic.SumAllPartNumbersAroundSymbols().Should().Be(4361);
    }

    [Fact]
    public void GetGearSymbols_ShouldReturn2Sets()
    {
        _schematic.MapLines("""
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
            """);
        _schematic.FinalizeMapping();

        _schematic.GetGearSymbolPartNumbers().Should().BeEquivalentTo([
            new int[] { 467, 35 },
            new int[] { 755, 598 }
        ]);
    }

    [Fact]
    public void SumGearRatios_ShouldReturn467835()
    {
        _schematic.MapLines("""
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
            """);
        _schematic.FinalizeMapping();

        _schematic.SumGearRatios().Should().Be(467835);
    }

    public class MapSchematicPartNumbersTestData : TheoryData<string, IEnumerable<Part>>
    {
        public MapSchematicPartNumbersTestData()
        {
            Add("467..114..", [new Part(467, 0, 0..2), new Part(114, 0, 5..7)]);
            Add("...*......", []);
            Add("..35..633.", [new Part(35, 0, 2..3), new Part(633, 0, 6..8)]);
            Add("......#...", []);
            Add("617*......", [new Part(617, 0, 0..2)]);
            Add(".....+.58.", [new Part(58, 0, 7..8)]);
            Add("..592.....", [new Part(592, 0, 2..4)]);
            Add("......755.", [new Part(755, 0, 6..8)]);
            Add("...$.*....", []);
            Add(".664.598..", [new Part(664, 0, 1..3), new Part(598, 0, 5..7)]);
        }
    }

    public class MapSchematicSymbolsTestData : TheoryData<string, IEnumerable<SymbolLocation>>
    {
        public MapSchematicSymbolsTestData()
        {
            Add("467..114..", []);
            Add("...*......", [new SymbolLocation('*', 0, 3)]);
            Add("..35..633.", []);
            Add("......#...", [new SymbolLocation('#', 0, 6)]);
            Add("617*......", [new SymbolLocation('*', 0, 3)]);
            Add(".....+.58.", [new SymbolLocation('+', 0, 5)]);
            Add("..592.....", []);
            Add("......755.", []);
            Add("...$.*....", [new SymbolLocation('$', 0, 3), new SymbolLocation('*', 0, 5)]);
            Add(".664.598..", []);
        }
    }
}
