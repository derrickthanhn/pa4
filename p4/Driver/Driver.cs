//Derrick Nguyen
//Driver.cs
//Driver to UnitTest

using System;

public class Driver
    {
        public static void Main(string[] args)
        {
            // Create a new Order
            var order = new Order
            {
                OrderNum = 1000,
                OrderTime = DateTime.Now,
                CustomerName = "John Jenkins",
                CustomerPhone = "253-312-4578",
                TaxAmount = 0,
                TariffAmount = 0,
                TotalAmount = 0
            };

            // Add DetailItems to the order
            var detail1 = new DetailItem
            {
                OrderNumber = 1000,
                DetailNumber = 1,
                StockID = "ELECT001",
                StockName = "42 Inch TV",
                StockPrice = 300.00m,
                Quantity = 1
            };

            var detail2 = new DetailItem
            {
                OrderNumber = 1000,
                DetailNumber = 2,
                StockID = "ELECT044",
                StockName = "Battery",
                StockPrice = 50.00m,
                Quantity = 2
            };

            order.AddDetailItem(detail1);
            order.AddDetailItem(detail2);

            // Perform a deep copy
            var copiedOrder = order.DeepCopy();

            // Display original and copied order information
            Console.WriteLine("Original Order:");
            DisplayOrder(order);

            Console.WriteLine("\nCopied Order:");
            DisplayOrder(copiedOrder);

            // Ensure deep copy integrity
            Console.WriteLine("\nDeep Copy Test:");
            Console.WriteLine($"Are DetailItems lists the same reference? {ReferenceEquals(order.DetailItems, copiedOrder.DetailItems)}");
        }

        private static void DisplayOrder(Order order)
        {
            Console.WriteLine($"Order Number: {order.OrderNum}");
            Console.WriteLine($"Order Time: {order.OrderTime}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"Customer Phone: {order.CustomerPhone}");
            Console.WriteLine($"Tax Amount: {order.TaxAmount}");
            Console.WriteLine($"Tariff Amount: {order.TariffAmount}");
            Console.WriteLine($"Total Amount: {order.TotalAmount}");
            Console.WriteLine("Details:");

            foreach (var detail in order.DetailItems)
            {
                Console.WriteLine($"\tDetail Number: {detail.DetailNumber}");
                Console.WriteLine($"\tStock ID: {detail.StockID}");
                Console.WriteLine($"\tStock Name: {detail.StockName}");
                Console.WriteLine($"\tStock Price: {detail.StockPrice}");
                Console.WriteLine($"\tQuantity: {detail.Quantity}");
                Console.WriteLine();
            }
        }
    }