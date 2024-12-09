//Derrick Nguyen
//DetailItem.cs
//help process orders for use
//Represents an order and details of the order
public class DetailItem
{
    //variables for details of detailitem
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
        return new DetailItem
        {
            OrderNumber = this.OrderNumber,
            DetailNumber = this.DetailNumber,
            StockID = this.StockID,
            StockName = this.StockName,
            StockPrice = this.StockPrice,
            Quantity = this.Quantity
        };
    }

    /// Default constructor for DetailItem.
    public DetailItem() { }

    /// <summary>
    /// Parameterized constructor for DetailItem.
    /// </summary>
    public DetailItem(int orderNumber, int detailNumber, string stockID, string stockName, decimal stockPrice, int quantity)
    {
        OrderNumber = orderNumber;
        DetailNumber = detailNumber;
        StockID = stockID;
        StockName = stockName;
        StockPrice = stockPrice;
        Quantity = quantity;
    }
}

