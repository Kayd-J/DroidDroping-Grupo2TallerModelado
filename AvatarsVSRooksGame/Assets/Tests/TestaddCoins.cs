using NUnit.Framework;
using UnityEngine;

public class TestaddCoins
{
    private GameObject go;
    private CoinManager cm;

    [SetUp]
    public void Setup()
    {
        CoinManager.Instance = null;
        go = new GameObject("CoinManagerGO");
        cm = go.AddComponent<CoinManager>();
        CoinManager.Instance = cm;
        cm.ResetCoins(100);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(go);
        CoinManager.Instance = null;
    }

    [Test]
    public void Test1AddCoins_IncreasesTotal()
    {
        cm.AddCoins(25);
        Assert.AreEqual(125, cm.GetTotalCoins());
    }

    [Test]
    public void Test2AddCoins_AddZeroDoesNothing()
    {
        cm.AddCoins(0);
        Assert.AreEqual(100, cm.GetTotalCoins());
    }

    [Test]
    public void Test3AddCoins_NegativeAmountDecreases()
    {
        cm.AddCoins(-10);
        Assert.AreEqual(90, cm.GetTotalCoins());
    }
}
