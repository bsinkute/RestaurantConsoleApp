namespace RestaurantSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(int id, DateTime orderDate)
        {
            Id = id;
            OrderDate = orderDate;
            Items = new List<OrderItem>();
        }

        public void AddOrderItem(MenuItem product, int quantity)
        {
            var orderItem = new OrderItem(product, quantity);
            Items.Add(orderItem);
        }
    }
}
