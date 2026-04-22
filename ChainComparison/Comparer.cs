using System;

namespace ChainComparison;

internal static class Comparer
{
    public static int SafeCompare<T>(T? left, T? right)
        where T : IComparable<T>
    {
        if (ReferenceEquals(left, right))
        {
            return 0;
        }

        if (left is null)
        {
            return int.MinValue;
        }

        if (right is null)
        {
            return int.MaxValue;
        }

        return left.CompareTo(right);
    }

    public static ChainComparisonResult<T> CreateEqual<T>(T left, T right)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, static x => x == 0);
    }

    public static ChainComparisonResult<T> CreateEqual<T>(T left, T right, bool previousResult)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, previousResult, static x => x == 0);
    }

    public static ChainComparisonResult<T> CreateInequal<T>(T left, T right)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, static x => x != 0);
    }

    public static ChainComparisonResult<T> CreateInequal<T>(T left, T right, bool previousResult)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, previousResult, static x => x != 0);
    }

    public static ChainComparisonResult<T> CreateGreaterThan<T>(T left, T right)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, static x => x > 0);
    }

    public static ChainComparisonResult<T> CreateGreaterThan<T>(T left, T right, bool previousResult)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, previousResult, static x => x > 0);
    }

    public static ChainComparisonResult<T> CreateGreaterThanOrEqual<T>(T left, T right)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, static x => x >= 0);
    }

    public static ChainComparisonResult<T> CreateGreaterThanOrEqual<T>(T left, T right, bool previousResult)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, previousResult, static x => x >= 0);
    }

    public static ChainComparisonResult<T> CreateLessThan<T>(T left, T right)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, static x => x < 0);
    }

    public static ChainComparisonResult<T> CreateLessThan<T>(T left, T right, bool previousResult)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, previousResult, static x => x < 0);
    }

    public static ChainComparisonResult<T> CreateLessThanOrEqual<T>(T left, T right)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, static x => x <= 0);
    }

    public static ChainComparisonResult<T> CreateLessThanOrEqual<T>(T left, T right, bool previousResult)
        where T : IComparable<T>
    {
        return CreateIntermediateResult(left, right, previousResult, static x => x <= 0);
    }

    private static ChainComparisonResult<T> CreateIntermediateResult<T>(
        T left,
        T right,
        Func<int, bool> comparer)
        where T : IComparable<T>
    {
        return new(left, right, comparer(SafeCompare(left, right)));
    }

    private static ChainComparisonResult<T> CreateIntermediateResult<T>(
        T left,
        T right,
        bool previousResult,
        Func<int, bool> comparer)
        where T : IComparable<T>
    {
        if (!previousResult)
        {
            return new(left, right, false);
        }

        return CreateIntermediateResult(left, right, comparer);
    }
}
