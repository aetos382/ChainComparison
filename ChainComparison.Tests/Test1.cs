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
}
