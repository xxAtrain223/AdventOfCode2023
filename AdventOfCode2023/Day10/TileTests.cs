using AdventOfCode2023.Utilities;

namespace AdventOfCode2023.Day10;

public class TileTests
{
    [Theory]
    [InlineData('|', TileType.NorthSouth)]
    [InlineData('-', TileType.EastWest)]
    [InlineData('L', TileType.NorthEast)]
    [InlineData('J', TileType.NorthWest)]
    [InlineData('7', TileType.SouthWest)]
    [InlineData('F', TileType.SouthEast)]
    [InlineData('.', TileType.Ground)]
    [InlineData('S', TileType.Start)]
    public void ShouldReturnTileType(char character, TileType expectedTileType)
    {
        Tile.ParseTileType(character).Should().Be(expectedTileType);
    }
}

public enum TileType
{
    NorthSouth, // |
    EastWest,   // -
    NorthEast,  // L
    NorthWest,  // J
    SouthWest,  // 7
    SouthEast,  // F
    Ground,     // .
    Start       // S
}

public record Tile
{
    public Tile(Vector2D<int> position, char character, int distanceToStart = 0) :
        this(position, ParseTileType(character), distanceToStart)
    {
    }

    public Tile(Vector2D<int> position, TileType type, int distanceToStart = 0)
    {
        Position = position;
        Type = type;
        DistanceToStart = distanceToStart;
    }

    public Vector2D<int> Position { get; }
    public TileType Type { get; }
    public int DistanceToStart { get; set; }

    public static TileType ParseTileType(char character) =>
        character switch
        {
            '|' => TileType.NorthSouth,
            '-' => TileType.EastWest,
            'L' => TileType.NorthEast,
            'J' => TileType.NorthWest,
            '7' => TileType.SouthWest,
            'F' => TileType.SouthEast,
            '.' => TileType.Ground,
            'S' => TileType.Start,
            _ => throw new ArgumentException("Unknown tile type character", nameof(character))
        };
}
