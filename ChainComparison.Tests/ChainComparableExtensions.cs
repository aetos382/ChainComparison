using System;

namespace ChainComparison.Tests;

internal static class ChainComparableExtensions
{
    public static ChainComparable<T> ToChainComparable<T>(this T value)
        where T : IComparable<T>
    {
        return new(value);
    }
}
