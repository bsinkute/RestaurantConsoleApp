namespace RestaurantSystem.Models
{
    public class CustomerReceipt : Receipt
    {
        public string RestaurantName { get; private set; }

        public CustomerReceipt(int id, DateTime date, Order order, string restaurantName)
            : base(id, date, order)
        {
            RestaurantName = restaurantName;
        }
    }
}
