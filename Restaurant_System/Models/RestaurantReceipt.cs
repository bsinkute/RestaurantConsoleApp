namespace RestaurantSystem.Models
{
    public class RestaurantReceipt : Receipt
    {
        public string RestaurantName { get; private set; }

        public RestaurantReceipt(int id, DateTime date, Order order, string restaurantName)
            : base(id, date, order)
        {
            RestaurantName = restaurantName;
        }
    }
}
