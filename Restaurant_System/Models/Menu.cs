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
            return $" Id.:";
        }
        public void AddMenuItem(int id, string name, decimal price)
        {
            MenuItem menuItem = new MenuItem(id, name, price);
            menuItems.Add(menuItem);
        }

        public void PrintMenu()
        {
            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine($"ID: {menuItem.Id}, Name: {menuItem.Name}, Price: {menuItem.Price}");
            }
        }
    }
}
