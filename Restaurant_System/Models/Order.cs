namespace RestaurantSystem.Models
{
    public class Order
    {
        public int NumberOfPeople { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public Order(int numberOfPeople, DateTime checkin)
        {
            NumberOfPeople = numberOfPeople;
            Checkin = checkin;
            Items = new List<OrderItem>();
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

        public override string ToString()
        {
            var itemsString = string.Join("\r\n", Items.Select(x => x.ToString()));
            return itemsString;
        }
    }
}
