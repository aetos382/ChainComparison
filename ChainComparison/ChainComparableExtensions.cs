using System;

namespace ChainComparison;

public static class ChainComparableExtensions
{
    public static ChainComparable<T> ToChainComparable<T>(this T value)
        where T : IComparable<T>
    {
        return new(value);
    }
}
