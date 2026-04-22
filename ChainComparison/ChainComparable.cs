using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace ChainComparison;

public readonly partial struct ChainComparable<T> :
    IEquatable<ChainComparable<T>>,
    IComparable<ChainComparable<T>>,
    IComparable
    where T : IComparable<T>
{
    public T Value { get; }

    public ChainComparable(T value)
    {
        this.Value = value;
    }

    /// <inheritdoc/>
    public int CompareTo(ChainComparable<T> other)
    {
        return Comparer.SafeCompare(this.Value, other.Value);
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return int.MaxValue;
        }

        if (obj is not ChainComparable<T> other)
        {
            throw new ArgumentException("Object must be of type ChainComparable<T>.");
        }

        return this.CompareTo(other);
    }

    /// <inheritdoc/>
    public bool Equals(ChainComparable<T> other)
    {
        return Comparer.SafeCompare(this.Value, other.Value) == 0;
    }

    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is not ChainComparable<T> other)
        {
            return false;
        }

        return this.Equals(other);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.Value?.GetHashCode() ?? 0;
    }

    public static implicit operator ChainComparable<T>(T value)
    {
        return new(value);
    }

    public static ChainComparisonResult<T> operator ==(ChainComparable<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateEqual(left.Value, right.Value);
    }

    public static ChainComparisonResult<T> operator ==(ChainComparable<T> left, ChainComparisonResult<T> right)
    {
        return Comparer.CreateEqual(left.Value, right.LeftValue);
    }

    public static ChainComparisonResult<T> operator !=(ChainComparable<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateInequal(left.Value, right.Value);
    }

    public static ChainComparisonResult<T> operator !=(ChainComparable<T> left, ChainComparisonResult<T> right)
    {
        return Comparer.CreateInequal(left.Value, right.LeftValue);
    }

    public static ChainComparisonResult<T> operator >(ChainComparable<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateGreaterThan(left.Value, right.Value);
    }

    public static ChainComparisonResult<T> operator >(ChainComparable<T> left, ChainComparisonResult<T> right)
    {
        return Comparer.CreateGreaterThan(left.Value, right.LeftValue);
    }

    public static ChainComparisonResult<T> operator <(ChainComparable<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateLessThan(left.Value, right.Value);
    }

    public static ChainComparisonResult<T> operator <(ChainComparable<T> left, ChainComparisonResult<T> right)
    {
        return Comparer.CreateLessThan(left.Value, right.LeftValue);
    }

    public static ChainComparisonResult<T> operator >=(ChainComparable<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateGreaterThanOrEqual(left.Value, right.Value);
    }

    public static ChainComparisonResult<T> operator >=(ChainComparable<T> left, ChainComparisonResult<T> right)
    {
        return Comparer.CreateGreaterThanOrEqual(left.Value, right.LeftValue);
    }

    public static ChainComparisonResult<T> operator <=(ChainComparable<T> left, ChainComparable<T> right)
    {
        return Comparer.CreateLessThanOrEqual(left.Value, right.Value);
    }

    public static ChainComparisonResult<T> operator <=(ChainComparable<T> left, ChainComparisonResult<T> right)
    {
        return Comparer.CreateLessThanOrEqual(left.Value, right.LeftValue);
    }
}

#if NET7_0_OR_GREATER

#pragma warning disable IDE0040
partial struct ChainComparable<T> :
    IComparisonOperators<ChainComparable<T>, ChainComparable<T>, ChainComparisonResult<T>>,
    IComparisonOperators<ChainComparable<T>, ChainComparisonResult<T>, ChainComparisonResult<T>>;

#pragma warning restore IDE0040

#endif
