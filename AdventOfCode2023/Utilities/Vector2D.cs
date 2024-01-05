using System.Numerics;

namespace AdventOfCode2023.Utilities;

public record struct Vector2D<T>(T X, T Y) :
    IAdditionOperators<Vector2D<T>, Vector2D<T>, Vector2D<T>>,
    ISubtractionOperators<Vector2D<T>, Vector2D<T>, Vector2D<T>>
    where T : IAdditionOperators<T, T, T>,
              ISubtractionOperators<T, T, T>
{
    public static Vector2D<T> operator +(Vector2D<T> left, Vector2D<T> right) =>
        new(left.X + right.X, left.Y + right.Y);

    public static Vector2D<T> operator -(Vector2D<T> left, Vector2D<T> right) =>
        new(left.X - right.X, left.Y - right.Y);
}

