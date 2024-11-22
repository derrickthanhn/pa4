//Derrick Nguyen
//UnitTest.cs
//unit tester to check if functions work

namespace pa4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void TestOrderCreation()
    {
        // Placeholder for testing Order creation.
        OrderClassLibrary.Order order = new OrderClassLibrary.Order();
        Assert.IsNotNull(order);
    }
    
    [TestMethod]
    public void TestDetailItemCreation()
    {
        // Placeholder for testing DetailItem creation.
        OrderClassLibrary.DetailItem detailItem = new OrderClassLibrary.DetailItem();
        Assert.IsNotNull(detailItem);
    }
}
