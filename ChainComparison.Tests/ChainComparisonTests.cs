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
    public void 小なり演算子(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() < b < c);
    }

    [TestMethod]
    [DataRow(1, 2, 3, true)]
    [DataRow(1, 1, 2, true)]   // 前が等値
    [DataRow(1, 1, 1, true)]   // 全等値
    [DataRow(3, 1, 5, false)]  // 前段失敗
    [DataRow(1, 3, 2, false)]  // 後段失敗
    public void 小なりイコール演算子(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() <= b <= c);
    }

    [TestMethod]
    [DataRow(3, 2, 1, true)]
    [DataRow(1, 3, 0, false)]  // 前段失敗
    [DataRow(3, 1, 2, false)]  // 後段失敗
    [DataRow(2, 2, 1, false)]  // 等値は false
    public void 大なり演算子(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() > b > c);
    }

    [TestMethod]
    [DataRow(3, 2, 1, true)]
    [DataRow(3, 3, 1, true)]   // 前が等値
    [DataRow(3, 3, 3, true)]   // 全等値
    [DataRow(1, 3, 0, false)]  // 前段失敗
    [DataRow(3, 1, 2, false)]  // 後段失敗
    public void 大なりイコール演算子(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() >= b >= c);
    }

    [TestMethod]
    [DataRow(1, 1, 1, true)]
    [DataRow(1, 2, 2, false)]  // 前段失敗
    [DataRow(1, 1, 2, false)]  // 後段失敗
    public void 等値演算子(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() == b == c);
    }

    [TestMethod]
    [DataRow(1, 2, 3, true)]
    [DataRow(1, 1, 2, false)]  // 前段失敗
    [DataRow(1, 2, 2, false)]  // 後段失敗
    public void 非等値演算子(int a, int b, int c, bool expected)
    {
        Assert.AreEqual(expected, a.ToChainComparable() != b != c);
    }

    [TestMethod]
    public void 小なり演算子_中間値がラップされていなくても正しく評価される()
    {
        Assert.IsTrue(1.ToChainComparable() < 2 < 3.ToChainComparable());
    }

    [TestMethod]
    public void 小なり演算子_末尾値がラップされていなくても正しく評価される()
    {
        Assert.IsTrue(1.ToChainComparable() < 2.ToChainComparable() < 3);
    }

    [TestMethod]
    public void 小なり演算子_3要素チェーンで全条件が真のとき真を返す()
    {
        Assert.IsTrue(1.ToChainComparable() < 2 < 3 < 4);
    }

    [TestMethod]
    public void 小なり演算子_3要素チェーンで途中の条件が偽のとき偽を返す()
    {
        Assert.IsFalse(1.ToChainComparable() < 2 < 1 < 4);
    }
}
