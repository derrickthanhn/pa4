//Derrick Nguyen
//OrderClassLibrary.cs
//OrderClassLibrary to help process orders for use


    //Represents customers order
    //Total must not be neg 
    //Ordernumber must be unique
public class Order
{
        public Order()
        {
            DetailItems = new List<DetailItem>();
        }

        //Attributes
        public int OrderNum { get; set; }
        public DateTime OrderTime { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TariffAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public List<DetailItem> DetailItems { get; set; }

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
            // Create a new Order instance
            var copy = new Order
            {
                OrderNum = this.OrderNum,
                OrderTime = this.OrderTime,
                CustomerName = this.CustomerName,
                CustomerPhone = this.CustomerPhone,
                TaxAmount = this.TaxAmount,
                TariffAmount = this.TariffAmount,
                TotalAmount = this.TotalAmount
            };

            // Deep copy each DetailItem
            foreach (var detailItem in this.DetailItems)
            {
                copy.DetailItems.Add(detailItem.DeepCopy());
            }

            return copy;
        }
}
    
