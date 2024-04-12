namespace RestaurantSystem.Models
{
    public class CustomerReceipt : Receipt
    {
        public CustomerReceipt(int id, DateTime date, Order order, string restaurantName)
            : base(id, date, order, restaurantName)
        {
        }
        public override string ToString()
        {
            return $" Id.: {Id}";
        }
    }
}
