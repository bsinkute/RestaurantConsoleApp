namespace RestaurantSystem.Models
{
    public class Drink : MenuItem
    {
        public Drink(int id, string name, decimal price) : base(id, name, price)
        {
        }

        public override string ToString()
        {
            return $" Id.: {Id}";
        }
    }
}
