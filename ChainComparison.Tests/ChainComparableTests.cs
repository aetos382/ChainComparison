using System;

namespace ChainComparison.Tests;

[TestClass]
public sealed class ChainComparableTests
{
    [TestMethod]
    [DataRow(1, 1, true)]
    [DataRow(1, 2, false)]
    public void 型付きEquals(int a, int b, bool expected)
    {
        Assert.AreEqual(expected, new ChainComparable<int>(a).Equals(new ChainComparable<int>(b)));
    }

    [TestMethod]
    [DataRow(1, 1, true)]
    [DataRow(1, 2, false)]
    public void オブジェクトEquals_同じ型(int a, int b, bool expected)
    {
        object boxed = new ChainComparable<int>(b);
        Assert.AreEqual(expected, new ChainComparable<int>(a).Equals(boxed));
    }

    [TestMethod]
    public void オブジェクトEquals_nullはfalseを返す()
    {
        Assert.IsFalse(new ChainComparable<int>(1).Equals(null));
    }

    [TestMethod]
    public void オブジェクトEquals_異なる型はfalseを返す()
    {
        Assert.IsFalse(new ChainComparable<int>(1).Equals("1"));
    }

    [TestMethod]
    public void GetHashCode_同じ値は同じコードを返す()
    {
        Assert.AreEqual(
            new ChainComparable<int>(42).GetHashCode(),
            new ChainComparable<int>(42).GetHashCode());
    }

    [TestMethod]
    [DataRow(1, 2, -1)]
    [DataRow(2, 2, 0)]
    [DataRow(3, 2, 1)]
    public void 型付きCompareTo(int a, int b, int expectedSign)
    {
        int result = new ChainComparable<int>(a).CompareTo(new ChainComparable<int>(b));
        Assert.AreEqual(expectedSign, Math.Sign(result));
    }

    [TestMethod]
    [DataRow(1, 2, -1)]
    [DataRow(2, 2, 0)]
    [DataRow(3, 2, 1)]
    public void オブジェクトCompareTo_同じ型(int a, int b, int expectedSign)
    {
        object boxed = new ChainComparable<int>(b);
        int result = new ChainComparable<int>(a).CompareTo(boxed);
        Assert.AreEqual(expectedSign, Math.Sign(result));
    }

    [TestMethod]
    public void オブジェクトCompareTo_nullは正の値を返す()
    {
        int result = new ChainComparable<int>(1).CompareTo(null);
        Assert.IsTrue(result > 0);
    }

    [TestMethod]
    public void オブジェクトCompareTo_異なる型はArgumentExceptionをスローする()
    {
        Assert.ThrowsExactly<ArgumentException>(
            () => new ChainComparable<int>(1).CompareTo("1"));
    }
}
