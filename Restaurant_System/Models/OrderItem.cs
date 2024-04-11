namespace RestaurantSystem.Models
{
    public class OrderItem
    {
        public MenuItem OrderedProduct { get; set; }
        public int Quantity { get; set; }

        public OrderItem(MenuItem product, int quantity)
        {
            OrderedProduct = product;
            Quantity = quantity;
        }
    }
}
