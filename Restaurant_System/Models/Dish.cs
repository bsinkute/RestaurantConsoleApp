namespace RestaurantSystem.Models
{
    public class Dish : MenuItem
    {
        public Dish(int id, string name, decimal price, DateTime addedDate) : base(id, name, price, addedDate)
        {
        }
    }
}
