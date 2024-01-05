using AdventOfCode2023.Utilities;

namespace AdventOfCode2023.Day10;

public class MapTests
{
    [Fact]
    public void ShouldParseSimpleMap1()
    {
        var textMap = """
            .....
            .S-7.
            .|.|.
            .L-J.
            .....
            """;

        Map.ParseTiles(textMap).Should().BeEquivalentTo([
            new Tile(new(1, 1), TileType.Start, 0),
            new Tile(new(1, 2), TileType.EastWest, 1),
            new Tile(new(1, 3), TileType.SouthWest, 2),
            new Tile(new(2, 3), TileType.NorthSouth, 3),
            new Tile(new(3, 3), TileType.NorthWest, 4),
            new Tile(new(3, 2), TileType.EastWest, 5),
            new Tile(new(3, 1), TileType.NorthEast, 6),
            new Tile(new(2, 1), TileType.NorthSouth, 7),
        ]);
    }

    [Fact]
    public void ShouldReturnStartPosition()
    {
        char[][] charGrid = [
            ['.', '.', '.', '.', '.'],
            ['.', 'S', '-', '7', '.'],
            ['.', '|', '.', '|', '.'],
            ['.', 'L', '-', 'J', '.'],
            ['.', '.', '.', '.', '.']
        ];

        Map.FindStartPosition(charGrid).Should().Be(new Vector2D<int>(1, 1));
    }

    [Theory]
    [ClassData(typeof(StartDirectionTestData))]
    public void ShouldReturnStartDirection(char[][] charGrid, Vector2D<int> expectedDirection)
    {
        var startPosition = new Vector2D<int>(1, 1);
        var actualDirection = Map.FindStartDirection(charGrid, startPosition);
        actualDirection.Should().Be(expectedDirection);
    }

    public class StartDirectionTestData : TheoryData<char[][], Vector2D<int>>
    {
        public StartDirectionTestData()
        {
            // Pipe to the north
            Add([
                ['.', '|', '.'],
                ['|', 'S', '|'],
                ['.', '-', '.'],
            ], new(-1, 0));
            Add([
                ['.', '7', '.'],
                ['7', 'S', 'L'],
                ['.', '7', '.'],
            ], new(-1, 0));
            Add([
                ['.', 'F', '.'],
                ['J', 'S', 'F'],
                ['.', 'F', '.'],
            ], new(-1, 0));

            // Pipe to the east
            Add([
                ['.', '-', '.'],
                ['|', 'S', '-'],
                ['.', '-', '.'],
            ], new(0, 1));
            Add([
                ['.', 'J', '.'],
                ['J', 'S', 'J'],
                ['.', 'F', '.'],
            ], new(0, 1));
            Add([
                ['.', 'L', '.'],
                ['7', 'S', '7'],
                ['.', '7', '.'],
            ], new(0, 1));

            // Pipe to the south
            Add([
                ['.', '-', '.'],
                ['|', 'S', '|'],
                ['.', '|', '.'],
            ], new(1, 0));
            Add([
                ['.', 'J', '.'],
                ['J', 'S', 'F'],
                ['.', 'L', '.'],
            ], new(1, 0));
            Add([
                ['.', 'L', '.'],
                ['7', 'S', 'L'],
                ['.', 'J', '.'],
            ], new(1, 0));

            // Pipe to the west
            Add([
                ['.', '-', '.'],
                ['-', 'S', '|'],
                ['.', '-', '.'],
            ], new(0, -1));
            Add([
                ['.', 'L', '.'],
                ['L', 'S', 'L'],
                ['.', '7', '.'],
            ], new(0, -1));
            Add([
                ['.', 'J', '.'],
                ['F', 'S', 'F'],
                ['.', 'F', '.'],
            ], new(0, -1));
        }
    }

    [Theory]
    [ClassData(typeof(NextDirectionTestData))]
    public void ShouldReturnNextDirection(char tileChar, Vector2D<int> previousDirection, Vector2D<int> expectedNextDirection)
    {
        Map.GetNextDirection(tileChar, previousDirection).Should().Be(expectedNextDirection);
    }

    public class NextDirectionTestData : TheoryData<char, Vector2D<int>, Vector2D<int>>
    {
        public NextDirectionTestData()
        {
            Add('|', new(1, 0), new(1, 0));
            Add('|', new(-1, 0), new(-1, 0));

            Add('-', new(0, 1), new(0, 1));
            Add('-', new(0, -1), new(0, -1));

            Add('L', new(1, 0), new(0, 1));
            Add('L', new(0, -1), new(-1, 0));

            Add('J', new(1, 0), new(0, -1));
            Add('J', new(0, 1), new(-1, 0));

            Add('7', new(0, 1), new(1, 0));
            Add('7', new(-1, 0), new(0, -1));

            Add('F', new(0, -1), new(1, 0));
            Add('F', new(-1, 0), new(0, 1));
        }
    }
}

