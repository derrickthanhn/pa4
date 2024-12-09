//Derrick Nguyen
//UnitTest.cs
//unit tester to check if functions work

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest
{
    //tests order creation
    [TestMethod]
    public void TestOrderCreation()
    {
        // Placeholder for testing Order creation.
        Order order = new Order();
        Assert.IsNotNull(order);
    }
    
    //tests deepcopy
    [TestMethod]
    public void DeepCopy_ShouldCreateNewInstanceWithSameValues()
    {
        // Arrange
        var original = new DetailItem
        {
            OrderNumber = 1000,
            DetailNumber = 1,
            StockID = "ELECT001",
            StockName = "42 Inch TV",
            StockPrice = 300.00m,
            Quantity = 1
        };

        // Act
        var copy = original.DeepCopy();

        // Assert
        Assert.IsNotNull(copy);
        Assert.AreNotSame(original, copy);
        Assert.AreEqual(original.OrderNumber, copy.OrderNumber);
        Assert.AreEqual(original.DetailNumber, copy.DetailNumber);
        Assert.AreEqual(original.StockID, copy.StockID);
        Assert.AreEqual(original.StockName, copy.StockName);
        Assert.AreEqual(original.StockPrice, copy.StockPrice);
        Assert.AreEqual(original.Quantity, copy.Quantity);
    }
    
    //tests total
    [TestMethod]
    public void CalculateTotal_ShouldReturnCorrectAmount()
    {
        // Arrange
        var order = new Order
        {
            DetailItems = new List<DetailItem>
            {
                new DetailItem { StockPrice = 300.00m, Quantity = 1 }, // Total: 300.00
                new DetailItem { StockPrice = 50.00m, Quantity = 2 }   // Total: 100.00
            }
        };
        
        // Assert
        Assert.AreEqual(400.00m, order.TotalAmount);
    }
}