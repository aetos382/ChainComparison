using System;
using System.Numerics;

namespace ChainComparison;

// ChainComparisonResult は値として扱われることを意図していない
#pragma warning disable CS0660, CS0661, CA1815

public readonly partial struct ChainComparisonResult<T>
    where T : IComparable<T>
{
    public ChainComparisonResult(
        T leftValue,
        T rightValue,
        bool result)
    {
        this.LeftValue = leftValue;
        this.RightValue = rightValue;
        this.Result = result;
    }

    public T LeftValue { get; }
    public T RightValue { get; }
    public bool Result { get; }

    public static implicit operator bool(ChainComparisonResult<T> result)
    {
        return result.Result;
    }

    public static bool operator true(ChainComparisonResult<T> result)
    {
        return result.Result;
    }

    public static bool operator false(ChainComparisonResult<T> result)
    {
        return !result.Result;
    }

    public static ChainComparisonResult<T> operator ==(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateEqual(left.RightValue, right.Value, left.Result);
    }

    public static ChainComparisonResult<T> operator !=(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateInequal(left.RightValue, right.Value, left.Result);
    }

    public static ChainComparisonResult<T> operator >(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateGreaterThan(left.RightValue, right.Value, left.Result);
    }

    public static ChainComparisonResult<T> operator <(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateLessThan(left.RightValue, right.Value, left.Result);
    }

    public static ChainComparisonResult<T> operator >=(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateGreaterThanOrEqual(left.RightValue, right.Value, left.Result);
    }

    public static ChainComparisonResult<T> operator <=(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateLessThanOrEqual(left.RightValue, right.Value, left.Result);
    }
}

#if NET7_0_OR_GREATER

#pragma warning disable IDE0040

partial struct ChainComparisonResult<T> :
    IComparisonOperators<ChainComparisonResult<T>, ChainComparable<T>, ChainComparisonResult<T>>;

#pragma warning restore IDE0040

#endif
