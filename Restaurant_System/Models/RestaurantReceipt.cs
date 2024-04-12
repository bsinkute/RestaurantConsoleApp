namespace RestaurantSystem.Models
{
    public class RestaurantReceipt : Receipt
    {
        public RestaurantReceipt(int id, DateTime date, Order order, string restaurantName)
             : base(id, date, order, restaurantName)
        {
        }

        public override string ToString()
        {
            return $" Id.: {Id}";
        }
    }
}
