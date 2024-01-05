using AdventOfCode2023.Utilities;

namespace AdventOfCode2023.Extensions;

public static class Char2DArraryExtension
{
    public static char GetValue(this char[][] char2dArray, Vector2D<int> index) =>
        char2dArray[index.X][index.Y];
}

