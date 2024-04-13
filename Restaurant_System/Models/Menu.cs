namespace RestaurantSystem.Models
{
    public class Menu
    {
        private List<MenuItem> menuItems;

        public Menu()
        {
            menuItems = new List<MenuItem>();
        }

        public override string ToString()
        {
            return string.Join("\r\n", menuItems.Select(item => item.ToString()));
        }

        public void AddMenuItem(int id, string name, decimal price)
        {
            MenuItem menuItem = new MenuItem(id, name, price);
            menuItems.Add(menuItem);
        }
    }
}
