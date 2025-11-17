using NUnit.Framework;
using UnityEngine;

public class Test1SpendCoins
{
    private GameObject go;
    private CoinManager cm;

    [SetUp]
    public void Setup()
    {
        // Make sure no leftover singleton is present
        CoinManager.Instance = null;
        go = new GameObject("CoinManagerGO");
        cm = go.AddComponent<CoinManager>();
        // Ensure singleton is set even if Awake/Start didn't run in EditMode
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
    public void Test1SpendCoins_SucceedsWhenEnough()
    {
        bool result = cm.SpendCoins(50);
        Assert.IsTrue(result, "SpendCoins should return true when there are enough coins");
        Assert.AreEqual(50, cm.GetTotalCoins(), "Total coins should be reduced by the spent amount");
    }

    [Test]
    public void Test2SpendCoins_FailsWhenNotEnough()
    {
        cm.ResetCoins(20);
        bool result = cm.SpendCoins(50);
        Assert.IsFalse(result, "SpendCoins should return false when there are not enough coins");
        Assert.AreEqual(20, cm.GetTotalCoins(), "Total coins should remain unchanged when spend fails");
    }

    [Test]
    public void Test3SpendCoins_ExactAmount()
    {
        cm.ResetCoins(50);
        bool result = cm.SpendCoins(50);
        Assert.IsTrue(result, "SpendCoins should succeed when spending exactly the available amount");
        Assert.AreEqual(0, cm.GetTotalCoins(), "Total coins should be 0 after spending the exact amount");
        // Intentionally incorrect expectation to force a failing test
        // Assert.AreEqual(1, cm.GetTotalCoins(), "(INTENTIONAL) Total coins should be 1 after spending the exact amount");
    }
}
