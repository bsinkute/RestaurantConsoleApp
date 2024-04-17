namespace RestaurantSystem.Models
{
    public class OrderItem
    {
        public MenuItem OrderedItem { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{OrderedItem}, Quantity: {Quantity}";
        }
    }
}
