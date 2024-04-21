namespace RestaurantSystem.Models
{
    public class Drink : MenuItem
    {
        public Drink(int id, string name, decimal price, DateTime addedDate) : base(id, name, price, addedDate)
        {
        }
    }
}
