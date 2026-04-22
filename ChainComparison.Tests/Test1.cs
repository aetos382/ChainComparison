namespace ChainComparison.Tests;

[TestClass]
public sealed class ChainComparisonTests
{
    [TestMethod]
    [DataRow(1, 2, 3, true)]
    [DataRow(3, 1, 5, false)]  // 前段失敗
    [DataRow(1, 3, 2, false)]  // 後段失敗
    [DataRow(5, 1, 0, false)]  // 両段失敗
    [DataRow(1, 1, 2, false)]  // 等値は false
    public void LessThan_ReturnsExpected(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() < b < c);
    }

    [TestMethod]
    [DataRow(1, 2, 3, true)]
    [DataRow(1, 1, 2, true)]   // 前が等値
    [DataRow(1, 1, 1, true)]   // 全等値
    [DataRow(3, 1, 5, false)]  // 前段失敗
    [DataRow(1, 3, 2, false)]  // 後段失敗
    public void LessThanOrEqual_ReturnsExpected(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() <= b <= c);
    }

    [TestMethod]
    [DataRow(3, 2, 1, true)]
    [DataRow(1, 3, 0, false)]  // 前段失敗
    [DataRow(3, 1, 2, false)]  // 後段失敗
    [DataRow(2, 2, 1, false)]  // 等値は false
    public void GreaterThan_ReturnsExpected(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() > b > c);
    }

    [TestMethod]
    [DataRow(3, 2, 1, true)]
    [DataRow(3, 3, 1, true)]   // 前が等値
    [DataRow(3, 3, 3, true)]   // 全等値
    [DataRow(1, 3, 0, false)]  // 前段失敗
    [DataRow(3, 1, 2, false)]  // 後段失敗
    public void GreaterThanOrEqual_ReturnsExpected(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() >= b >= c);
    }

    [TestMethod]
    [DataRow(1, 1, 1, true)]
    [DataRow(1, 2, 2, false)]  // 前段失敗
    [DataRow(1, 1, 2, false)]  // 後段失敗
    public void Equal_ReturnsExpected(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() == b == c);
    }

    [TestMethod]
    [DataRow(1, 2, 3, true)]
    [DataRow(1, 1, 2, false)]  // 前段失敗
    [DataRow(1, 2, 2, false)]  // 後段失敗
    public void NotEqual_ReturnsExpected(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() != b != c);
    }

    // 暗黙的変換: 中間値がラップされていない
    [TestMethod]
    public void LessThan_MiddleValueUnwrapped_ReturnsTrue()
    {
        Assert.IsTrue(1.ToChainComparable() < 2 < 3.ToChainComparable());
    }

    // 暗黙的変換: 末尾値がラップされていない
    [TestMethod]
    public void LessThan_LastValueUnwrapped_ReturnsTrue()
    {
        Assert.IsTrue(1.ToChainComparable() < 2.ToChainComparable() < 3);
    }

    // 3要素チェーン
    [TestMethod]
    public void LessThan_TripleChain_ReturnsTrue()
    {
        Assert.IsTrue(1.ToChainComparable() < 2 < 3 < 4);
    }

    [TestMethod]
    public void LessThan_TripleChain_MiddleFails_ReturnsFalse()
    {
        Assert.IsFalse(1.ToChainComparable() < 2 < 1 < 4);
    }
}
