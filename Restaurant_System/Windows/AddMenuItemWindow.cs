﻿using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class AddMenuItemWindow
    {
        private readonly IMenuService _menuService;
        public AddMenuItemWindow(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public void Load()
        {
            Console.Clear();
            List<MenuItem> menuItems = new List<MenuItem>();
            while (true)
            {
                Console.WriteLine("Add new menu item:");
                Console.Write("Type '1' for Dish or '2' for Drink: ");

                bool isChoiseCorrect = int.TryParse(Console.ReadLine(), out int choise);
                while (!isChoiseCorrect || choise < 1 || choise > 2)
                {
                    Console.Write("Invalid type selection. Please try again: ");
                    isChoiseCorrect = int.TryParse(Console.ReadLine(), out choise);
                }

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");

                bool isPriceCorrect = decimal.TryParse(Console.ReadLine(), out decimal price);
                while (!isPriceCorrect || price <= 0)
                {
                    Console.Write("Invalid Price format. Please try again: ");
                    isPriceCorrect = decimal.TryParse(Console.ReadLine(), out price);
                }

                MenuItem menuItem;
                if (choise == 1)
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
