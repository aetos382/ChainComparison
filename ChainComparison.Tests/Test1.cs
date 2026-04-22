namespace ChainComparison.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        var a = 1.ToChainComparable();
        var b = 2.ToChainComparable();
        var c = 3.ToChainComparable();

        Assert.IsTrue(a < b < c);
    }

    [TestMethod]
    public void TestMethod2()
    {
        var a = 1.ToChainComparable();
        var b = 2;
        var c = 3.ToChainComparable();

        Assert.IsTrue(a < b < c);
    }

    [TestMethod]
    public void TestMethod3()
    {
        var a = 1.ToChainComparable();
        var b = 2.ToChainComparable();
        var c = 3;

        Assert.IsTrue(a < b < c);
    }

    // 前段の比較が false の場合、全体も false になるべき
    [TestMethod]
    public void LessThanReturnsFalseWhenFirstComparisonFails()
    {
        var a = 3.ToChainComparable();
        var b = 1.ToChainComparable();
        var c = 5.ToChainComparable();

        Assert.IsFalse(a < b < c);
    }

    [TestMethod]
    public void LessThanReturnsFalseWhenSecondComparisonFails()
    {
        var a = 1.ToChainComparable();
        var b = 3.ToChainComparable();
        var c = 2.ToChainComparable();

        Assert.IsFalse(a < b < c);
    }

    [TestMethod]
    public void LessThanReturnsFalseWhenBothComparisonsFail()
    {
        var a = 5.ToChainComparable();
        var b = 1.ToChainComparable();
        var c = 0.ToChainComparable();

        Assert.IsFalse(a < b < c);
    }
}
