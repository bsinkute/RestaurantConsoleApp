namespace RestaurantSystem.Models
{
    public class RestaurantReceipt : Receipt
    {
        public int TableId { get; private set; }
        public RestaurantReceipt(int tableId, int id, DateTime date, Order order, string restaurantName)
             : base(id, date, order, restaurantName)
        {
            TableId = tableId;
        }
    }
}
