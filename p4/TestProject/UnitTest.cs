//Derrick Nguyen
//UnitTest.cs
//unit tester to check if functions work

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace p4;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void TestOrderCreation()
    {
        // Placeholder for testing Order creation.
        Order order = new Order();
        Assert.IsNotNull(order);
    }
    
    [TestMethod]
    public void TestDetailItemCreation()
    {
        // Placeholder for testing DetailItem creation.
        DetailItem detailItem = new DetailItem();
        Assert.IsNotNull(detailItem);
    }
}