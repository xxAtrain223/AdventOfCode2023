using FluentAssertions;
using System.Linq;
using System.Text.RegularExpressions;

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

public record struct Part(int PartNumber, int Row, Range Indices);

public record struct SymbolLocation(char Symbol, int Row, int Column);

public partial class Schematic
{
    private int _currentLine = -1;
    private int _columnCount = -1;

    private readonly List<Part> _parts = [];

    private int[,]? _partNumbers;

    public IEnumerable<Part> MappedParts => _parts;

    private readonly List<SymbolLocation> _symbols = [];

    public IEnumerable<SymbolLocation> MappedSymbols => _symbols;

    public void MapLines(string schematictext)
    {
        foreach (var line in schematictext.Split('\n'))
        {
            MapLine(line.Trim());
        }
    }

    public void MapLine(string line)
    {
        _currentLine++;
        _columnCount = line.Length;
        MapPartNumbers(line);
        MapSymbols(line);
    }

    private void MapPartNumbers(string line)
    {
        var matches = PartNumberRegex().Matches(line);

        foreach (Match match in matches)
        {
            var partNumber = int.Parse(match.ValueSpan);
            var indices = new Range(match.Index, match.Index + match.Length - 1);
            var part = new Part(partNumber, _currentLine, indices);

            _parts.Add(part);
        }
    }

    private void MapSymbols(string line)
    {
        var matches = SymbolRegex().Matches(line);

        foreach (Match match in matches)
        {
            var symbolChar = match.ValueSpan[0];
            var column = match.Index;
            var symbolLocation = new SymbolLocation(symbolChar, _currentLine, column);

            _symbols.Add(symbolLocation);
        }
    }

    public void FinalizeMapping()
    {
        _partNumbers = new int[_currentLine + 1, _columnCount];

        foreach (var part in _parts)
        {
            for (int columnIndex = part.Indices.Start.Value;
                 columnIndex <= part.Indices.End.Value;
                 columnIndex++)
            {
                _partNumbers[part.Row, columnIndex] = part.PartNumber;
            }
        }
    }

    public int GetPartNumberAtLocation(int row, int column)
    {
        if (_partNumbers is null)
        {
            throw new InvalidOperationException("The schematic mapping has not been finalized.");
        }

        if (row < _partNumbers.GetLowerBound(0) ||
            row > _partNumbers.GetUpperBound(0) ||
            column < _partNumbers.GetLowerBound(1) ||
            column > _partNumbers.GetUpperBound(1))
        {
            return 0;
        }

        return _partNumbers[row, column];
    }

    public IEnumerable<int> GetPartNumbersAroundLocation(int row, int column)
    {
        for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
        {
            for (int columnOffset = -1; columnOffset <= 1; columnOffset++)
            {
                var partNumber = GetPartNumberAtLocation(row + rowOffset, column + columnOffset);

                if (partNumber != 0)
                {
                    yield return partNumber;
                }
            }
        }
    }

    public IEnumerable<int> GetPartNumbersAroundSymbols()
    {
        var partNumbers = new HashSet<int>();

        foreach (var symbol in _symbols)
        {
            foreach (var partNumber in GetPartNumbersAroundLocation(symbol.Row, symbol.Column))
            {
                partNumbers.Add(partNumber);
            }
        }

        return partNumbers;
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex PartNumberRegex();

    [GeneratedRegex(@"[^0123456789.]")]
    private static partial Regex SymbolRegex();
}
