﻿namespace AdventOfCode2023.Extensions;

public static class IEnumerableExtensions
{
    public static IEnumerable<TResult> SelectWithPrevious<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TSource, TResult> projection)
    {
        using var iterator = source.GetEnumerator();
        
        if (iterator.MoveNext() == false)
        {
            yield break;
        }

        TSource previous = iterator.Current;
        while (iterator.MoveNext())
        {
            yield return projection(previous, iterator.Current);
            previous = iterator.Current;
        }
    }
}
