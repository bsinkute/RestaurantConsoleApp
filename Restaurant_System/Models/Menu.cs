namespace RestaurantSystem.Models
{
    public class Menu
    {
        public List<MenuItem> Items { get; set; }

        public Menu() 
        {
            Items = new List<MenuItem>();
        }

        public override string ToString()
        {
            return string.Join("\r\n", Items.Select(item => item.ToString()));
        }
    }
}
