using AdventOfCode2023.Utilities;

namespace AdventOfCode2023.Day10;

public class Map
{
    public static IEnumerable<Tile> ParseTiles(string textMap)
    {
        var charGrid = textMap
            .SplitByLine()
            .Select(l => l.ToCharArray())
            .ToArray();

        var position = FindStartPosition(charGrid);
        var tileChar = charGrid.GetValue(position);
        var distanceFromStart = 0;
        yield return new Tile(position, tileChar, distanceFromStart);

        var direction = FindStartDirection(charGrid, position);
        position += direction;
        distanceFromStart++;
        tileChar = charGrid.GetValue(position);

        while (tileChar != 'S')
        {
            yield return new Tile(position, tileChar, distanceFromStart);
            
            direction = GetNextDirection(tileChar, direction);
            position += direction;
            distanceFromStart++;
            tileChar = charGrid.GetValue(position);
        }

        yield break;
    }

    public static Vector2D<int> FindStartPosition(char[][] charGrid)
    {
        for (int row = 0; row < charGrid.Length; row++)
        {
            for (int column = 0; column < charGrid[row].Length; column++)
            {
                if (charGrid[row][column] == 'S')
                {
                    return new(row, column);
                }
            }
        }

        throw new Exception("Start not found");
    }

    public static Vector2D<int> FindStartDirection(char[][] charGrid, Vector2D<int> startPosition)
    {
        var northDirection = new Vector2D<int>(-1, 0);
        var northChar = charGrid.GetValue(startPosition + northDirection);
        if (northChar is '|' or '7' or 'F')
        {
            return northDirection;
        }

        var eastDirection = new Vector2D<int>(0, 1);
        var eastChar = charGrid.GetValue(startPosition + eastDirection);
        if (eastChar is '-' or 'J' or '7')
        {
            return eastDirection;
        }

        var southDirection = new Vector2D<int>(1, 0);
        var southChar = charGrid.GetValue(startPosition + southDirection);
        if (southChar is '|' or 'J' or 'L')
        {
            return southDirection;
        }

        var westDirection = new Vector2D<int>(0, -1);
        var westChar = charGrid.GetValue(startPosition + westDirection);
        if (westChar is '-' or 'L' or 'F')
        {
            return westDirection;
        }

        throw new Exception("No valid direction");
    }

    internal static Vector2D<int> GetNextDirection(char tileChar, Vector2D<int> previousDirection)
    {
        if (tileChar == '|' && previousDirection == new Vector2D<int>(1, 0)) return new Vector2D<int>(1, 0);
        if (tileChar == '|' && previousDirection == new Vector2D<int>(-1, 0)) return new Vector2D<int>(-1, 0);

        if (tileChar == '-' && previousDirection == new Vector2D<int>(0, 1)) return new Vector2D<int>(0, 1);
        if (tileChar == '-' && previousDirection == new Vector2D<int>(0, -1)) return new Vector2D<int>(0, -1);

        if (tileChar == 'L' && previousDirection == new Vector2D<int>(1, 0)) return new Vector2D<int>(0, 1);
        if (tileChar == 'L' && previousDirection == new Vector2D<int>(0, -1)) return new Vector2D<int>(-1, 0);

        if (tileChar == 'J' && previousDirection == new Vector2D<int>(1, 0)) return new Vector2D<int>(0, -1);
        if (tileChar == 'J' && previousDirection == new Vector2D<int>(0, 1)) return new Vector2D<int>(-1, 0);

        if (tileChar == '7' && previousDirection == new Vector2D<int>(0, 1)) return new Vector2D<int>(1, 0);
        if (tileChar == '7' && previousDirection == new Vector2D<int>(-1, 0)) return new Vector2D<int>(0, -1);

        if (tileChar == 'F' && previousDirection == new Vector2D<int>(0, -1)) return new Vector2D<int>(1, 0);
        if (tileChar == 'F' && previousDirection == new Vector2D<int>(-1, 0)) return new Vector2D<int>(0, 1);

        throw new Exception($"Invalid {nameof(tileChar)} and {nameof(previousDirection)} combination");
    }
}

