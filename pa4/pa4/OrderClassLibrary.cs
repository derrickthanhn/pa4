//Derrick Nguyen
//OrderClassLibrary.cs
//OrderClassLibrary to help process orders for use

namespace pa4;
using System;
using System.Collections.Generic;

public class OrderClassLibrary
{
    
    //Represents customers order
    //Total must not be neg 
    //Ordernumber must be unique
    public class Order
    {
        //Attributes
        public int OrderNum { get; set; }
        public DateTime OrderTime { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TariffAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public List<DetailItem> DetailItems { get; set; }
        public Order()
        {
            DetailItems = new List<DetailItem>();
        }
        //Adds a item order to order
        //pre: must not be null
        //post: item is added
        public void AddDetailItem(DetailItem detailItem)
        {
            if (detailItem == null) throw new ArgumentNullException(nameof(detailItem));
            DetailItems.Add(detailItem);
        }
        //Deep copy constructor
        //creates new isntane of order wtih all detail copied
        public Order DeepCopy()
        {
            return null;
        }
    }

    //Represents an order
    public class DetailItem
    {
        public int OrderNumber { get; set; }
        public int DetailNumber { get; set; }
        public string StockID { get; set; }
        public string StockName { get; set; }
        public decimal StockPrice { get; set; }
        public int Quantity { get; set; }
        
        //Creates a deep copy of the order
        //deep copy constructor
        public DetailItem DeepCopy()
        {
            return null;
        }
    }
    
    //Handles order processing
    public class OrderProcessor
    {
        //processes order by calculating tariff, amount, and tax
        //pre: must have one item
        //post: all calculated
        public void ProcessOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            decimal totalAmount = 0;
            decimal tariffAmount = 0;

            foreach (var detail in order.DetailItems)            
            {
                totalAmount += detail.StockPrice * detail.Quantity;
                // Apply 5% tariff if the StockID starts with "ELECT"
                if (detail.StockID.StartsWith("ELECT", StringComparison.OrdinalIgnoreCase))
                {
                    tariffAmount += (detail.StockPrice * detail.Quantity) * 0.05m;
                }
            }

            order.TariffAmount = tariffAmount;
            order.TaxAmount = totalAmount * 0.10m;
            order.TotalAmount = totalAmount + order.TaxAmount + tariffAmount;
        }
    }
}