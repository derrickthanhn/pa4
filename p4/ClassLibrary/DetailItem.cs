//Derrick Nguyen
//DetailItem.cs
//help process orders for use
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