using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace ChainComparison;

public readonly partial struct ChainComparisonResult<T> :
    IEquatable<ChainComparisonResult<T>>,
    IComparable<ChainComparisonResult<T>>,
    IComparable
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

    /// <inheritdoc />
    public bool Equals(ChainComparisonResult<T> other)
    {
        return this.Result == other.Result;
    }

    /// <inheritdoc />
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is not ChainComparisonResult<T> other)
        {
            return false;
        }

        return this.Equals(other);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return this.Result ? 1 : 0;
    }

    public int CompareTo(ChainComparisonResult<T> other)
    {
        return Comparer.SafeCompare(this.RightValue, other.LeftValue);
    }

    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return int.MaxValue;
        }

        if (obj is not ChainComparisonResult<T> other)
        {
            throw new ArgumentException();
        }

        return this.CompareTo(other);
    }

    public static ChainComparisonResult<T> operator ==(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateEqual(left.RightValue, right.Value);
    }

    public static ChainComparisonResult<T> operator !=(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateInequal(left.RightValue, right.Value);
    }

    public static ChainComparisonResult<T> operator >(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateGreaterThan(left.RightValue, right.Value);
    }

    public static ChainComparisonResult<T> operator <(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateLessThan(left.RightValue, right.Value);
    }

    public static ChainComparisonResult<T> operator >=(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateGreaterThanOrEqual(left.RightValue, right.Value);
    }

    public static ChainComparisonResult<T> operator <=(ChainComparisonResult<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateLessThanOrEqual(left.RightValue, right.Value);
    }
}

#if NET7_0_OR_GREATER

#pragma warning disable IDE0040
partial struct ChainComparisonResult<T> :
    IComparisonOperators<ChainComparisonResult<T>, ChainComparable<T>, ChainComparisonResult<T>>;

#pragma warning restore IDE0040

#endif
