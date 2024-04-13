namespace RestaurantSystem.Models
{
    public class Dish : MenuItem
    {
        public Dish(int id, string name, decimal price) : base(id, name, price)
        {
        }
    }
}
