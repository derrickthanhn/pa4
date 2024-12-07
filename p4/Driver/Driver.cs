//Derrick Nguyen
//Driver.cs
//Driver to UnitTest

using System;

public class Driver
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Order System Driver - Demonstrating Class Functionality");

        // Create an order
        var order = new OrderClassLibrary.Order
        {
            OrderNum = 1000,
            OrderTime = DateTime.Now,
            CustomerName = "John Jenkins",
            CustomerPhone = "253-312-4578",
            TaxAmount = 0,
            TariffAmount = 0,
            TotalAmount = 0
        };

        // Add detail items to the order
        var detail1 = new OrderClassLibrary.DetailItem
        {
            DetailNumber = 1,
            StockID = "ELECT001",
            StockName = "42 Inch TV",
            StockPrice = 300,
            Quantity = 1
        };

        var detail2 = new OrderClassLibrary.DetailItem
        {
            DetailNumber = 2,
            StockID = "ELECT044",
            StockName = "Battery",
            StockPrice = 50,
            Quantity = 2
        };

        order.AddDetailItem(detail1);
        order.AddDetailItem(detail2);

        // Display the order summary
        Console.WriteLine($"Order Summary for {order.CustomerName}:");
        Console.WriteLine($"Order Number: {order.OrderNum}");
        Console.WriteLine($"Order Date & Time: {order.OrderTime}");
        Console.WriteLine($"Customer Phone: {order.CustomerPhone}");
        Console.WriteLine($"Tax Amount: {order.TaxAmount:C}");
        Console.WriteLine($"Tariff Amount: {order.TariffAmount:C}");
        Console.WriteLine($"Total Amount: {order.TotalAmount:C}");

        Console.WriteLine("Detail Items:");
        foreach (var item in order.DetailItems)
        {
            Console.WriteLine($" - {item.StockName} (x{item.Quantity}): {item.StockPrice:C} each");
        }

        Console.WriteLine("Driver execution completed.");
    }
}