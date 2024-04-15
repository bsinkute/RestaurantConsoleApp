using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class AddMenuItemWindow
    {
        public void Load()
        {
            Console.Clear();
            List<MenuItem> menuItems = new List<MenuItem>();
            while (true)
            {
                Console.WriteLine("Add new menu item:");
                Console.Write("Type 'D' for Dish or 'G' for Drink: ");
                string typeInput = Console.ReadLine().ToLower();

                if (typeInput != "d" && typeInput != "g")
                {
                    Console.WriteLine("Invalid type selection. Please try again.");
                    continue;
                }

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                string priceInput = Console.ReadLine();

                if (!decimal.TryParse(priceInput, out decimal price))
                {
                    Console.WriteLine("Invalid Price format. Please try again.");
                    continue;
                }

                MenuItem menuItem;
                if (typeInput == "d")
                {
                    menuItem = new Dish(1, name, price);
                }
                else
                {
                    menuItem = new Drink(1, name, price);
                }

                menuItems.Add(menuItem);

                Console.WriteLine("Do you want to add another item? (yes/no)");
                string addAnotherInput = Console.ReadLine().ToLower();

                if (addAnotherInput != "yes" && addAnotherInput != "y")
                    break;
            }



            Console.WriteLine("Updated menu:");
            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine(menuItem);
            }
            Console.ReadLine();
        }
    }
}
