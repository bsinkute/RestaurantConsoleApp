namespace RestaurantSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public Order(int id, DateTime checkin, DateTime checkout)
        {
            Id = id;
            Checkin = checkin;
            Checkout = checkout;
            Items = new List<OrderItem>();
        }

        public void AddOrderItem(MenuItem product, int quantity)
        {
            var orderItem = new OrderItem(product, quantity);
            Items.Add(orderItem);
        }

        public override string ToString()
        {
            return $" Id.: {Id}";
        }
    }
}
