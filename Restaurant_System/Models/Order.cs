namespace RestaurantSystem.Models
{
    public class Order
    {
        public int NumberOfPeople { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int TableId {  get; set; }
        public int TableNumberOfSeats {  get; set; }

        private decimal vatRate = 0.21m;

        public Order(int numberOfPeople, DateTime checkin, int tableId, int tableNumberOfSeats)
        {
            NumberOfPeople = numberOfPeople;
            Checkin = checkin;
            Items = new List<OrderItem>();
            TableId = tableId;
            TableNumberOfSeats = tableNumberOfSeats;
        }

        public void AddOrderItem(MenuItem product, int quantity)
        {
            var orderItem = new OrderItem(product, quantity);
            Items.Add(orderItem);
        }

        public void CheckoutOrder(DateTime checkoutDate) 
        {
            Checkout = checkoutDate;
        }

        public decimal TotalAmountVatIncluded()
        {
            decimal totalAmount = 0;
            foreach (var item in Items)
            {
                totalAmount += item.Quantity * item.OrderedItem.Price;
            }
            return totalAmount;
        }

        public decimal TotalAmountWithoutVat()
        {
            return TotalAmountVatIncluded() - VatAmount();
        }

        public decimal VatAmount()
        {
            return TotalAmountVatIncluded() * vatRate;
        }

        public override string ToString()
        {
            var itemsString = string.Join("\r\n", Items.Select(x => x.ToString()));
            return itemsString;
        }
    }
}
