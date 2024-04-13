namespace RestaurantSystem.Models
{
    public class OrderItem
    {
        public MenuItem OrderedItem { get; set; }
        public int Quantity { get; set; }

        public OrderItem(MenuItem product, int quantity)
        {
            OrderedItem = product;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{OrderedItem}, Quantity: {Quantity}";
        }
    }
}
