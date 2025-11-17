using NUnit.Framework;
using UnityEngine;

public class Test2CanAfford
{
    private GameObject go;
    private CoinManager cm;

    [SetUp]
    public void Setup()
    {
        CoinManager.Instance = null;
        go = new GameObject("CoinManagerGO");
        cm = go.AddComponent<CoinManager>();
        // Ensure singleton assigned for EditMode tests
        CoinManager.Instance = cm;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(go);
        CoinManager.Instance = null;
    }

    [Test]
    public void Test1CanAfford_TrueWhenEnough()
    {
        cm.ResetCoins(100);
        Assert.IsTrue(cm.CanAfford(50), "CanAfford should return true when there are more coins than required");
    }

    [Test]
    public void Test2CanAfford_FalseWhenNotEnough()
    {
        cm.ResetCoins(10);
        Assert.IsFalse(cm.CanAfford(50), "CanAfford should return false when there are not enough coins");
    }

    [Test]
    public void Test3CanAfford_ExactAmount()
    {
        cm.ResetCoins(50);
        Assert.IsTrue(cm.CanAfford(50), "CanAfford should return true when the amount equals total coins");
    }
}
