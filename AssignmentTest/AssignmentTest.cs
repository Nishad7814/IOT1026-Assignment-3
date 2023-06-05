using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PackTests
{
    [TestMethod]
    public void Constructor_InitializesObjectCorrectly()
    {
        int maxCount = 10;
        float maxVolume = 20f;
        float maxWeight = 30f;

        Pack pack = new Pack(maxCount, maxVolume, maxWeight);

        Assert.AreEqual(maxCount, pack.GetMaxCount());
        Assert.AreEqual(0f, pack.GetVolume());
        Assert.AreEqual(0f, pack.GetWeight());
    }

    [TestMethod]
    public void Add_AddsSingleItemToEmptyPack()
    {
        Pack pack = new Pack();

        bool result = pack.Add(new Pack.Arrow());

        Assert.IsTrue(result);
        Assert.AreEqual(0.1f, pack.GetVolume());
        Assert.AreEqual(0.1f, pack.GetWeight());
    }

    [TestMethod]
    public void Add_AddsMultipleItemsWithinConstraints()
    {
        Pack pack = new Pack();

        bool result1 = pack.Add(new Pack.Arrow());
        bool result2 = pack.Add(new Pack.Bow());
        bool result3 = pack.Add(new Pack.Rope());

        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.IsTrue(result3);
        Assert.AreEqual(3, pack.GetMaxCount());
        Assert.AreEqual(3.1f, pack.GetVolume());
        Assert.AreEqual(2.1f, pack.GetWeight());
    }

    [TestMethod]
    public void Add_ExceedsPackConstraints_ReturnsFalse()
    {
        Pack pack = new Pack(1, 1f, 1f);

        bool result1 = pack.Add(new Pack.Rope());
        bool result2 = pack.Add(new Pack.Water());

        Assert.IsTrue(result1);
        Assert.IsFalse(result2);
        Assert.AreEqual(1, pack.GetMaxCount());
        Assert.AreEqual(1f, pack.GetVolume());
        Assert.AreEqual(3f, pack.GetWeight());
    }

    [TestMethod]
    public void Add_AtPackConstraints_ReturnsFalse()
    {
        Pack pack = new Pack(1, 1f, 1f);

        bool result1 = pack.Add(new Pack.Water());
        bool result2 = pack.Add(new Pack.Food());

        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.AreEqual(1, pack.GetMaxCount());
        Assert.AreEqual(1.5f, pack.GetVolume());
        Assert.AreEqual(3f, pack.GetWeight());
    }

    [TestMethod]
    public void Add_WithNegativeValues_ThrowsException()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Pack(-1, -1f, -1f));
    }

    [TestMethod]
    public void Add_WithNegativeWeightOrVolume_ThrowsException()
    {
        Pack pack = new Pack();

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Pack.Arrow()));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Pack.Bow()));
    }

    [TestMethod]
    public void Add_WithZeroWeightOrVolume_ThrowsException()
    {
        Pack pack = new Pack();

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Pack.Rope()));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => pack.Add(new Pack.Water()));
    }
}
