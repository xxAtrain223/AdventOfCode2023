namespace AdventOfCode2023.Day3;

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

    public void MapLines(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            MapLine(line);
        }
    }

    public void MapFile(IEnumerable<string> lines)
    {
        MapLines(lines);
        FinalizeMapping();
    }

    public void MapFile(FileInfo file)
    {
        MapLines(File.ReadLines(file.FullName));
        FinalizeMapping();
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

    public IEnumerable<int> GetPartNumbersAroundSymbols() => _symbols
        .SelectMany(s => GetPartNumbersAroundLocation(s.Row, s.Column).Distinct());

    public int SumAllPartNumbersAroundSymbols() =>
        GetPartNumbersAroundSymbols().Sum();

    public IEnumerable<int[]> GetGearSymbolPartNumbers() =>
        _symbols.Where(s => s.Symbol == '*')
        .Select(s => GetPartNumbersAroundLocation(s.Row, s.Column).Distinct().ToArray())
        .Where(p => p.Length == 2);

    public int SumGearRatios() =>
        GetGearSymbolPartNumbers()
        .Sum(r => r[0] * r[1]);

    [GeneratedRegex(@"\d+")]
    private static partial Regex PartNumberRegex();

    [GeneratedRegex(@"[^0123456789.]")]
    private static partial Regex SymbolRegex();
}
