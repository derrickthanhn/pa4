//Derrick Nguyen
//Process.cs
//help process orders for use

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
                tariffAmount += detail.StockPrice * detail.Quantity * 0.05m;
        }

        order.TariffAmount = tariffAmount;
        order.TaxAmount = totalAmount * 0.10m;
        order.TotalAmount = totalAmount + order.TaxAmount + tariffAmount;
    }
}