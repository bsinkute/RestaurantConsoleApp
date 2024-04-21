using RestaurantSystem.Infrastructure;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services
{
    public class MenuService : IMenuService
    {
        private readonly IDataService<List<Dish>> _dishDataService;
        private readonly IDataService<List<Drink>> _drinkDataService;
        public MenuService(IDataService<List<Dish>> dishDataService, IDataService<List<Drink>> drinkDataService)
        {
            _dishDataService = dishDataService;
            _drinkDataService = drinkDataService;
        }
        public void AddMenuItem(MenuItem menuItem)
        {
            Menu menu = GetMenu();
            if (menu.Items.Count == 0)
            {
                menuItem.Id = 1;
            }
            else
            {
                menuItem.Id = menu.Items.Max(o => o.Id) + 1;
            }

            if (menuItem is Dish dish)
            {
                SaveMenuItem(dish, _dishDataService);
            }

            if (menuItem is Drink drink)
            {
                SaveMenuItem(drink, _drinkDataService);
            }
        }

        private void SaveMenuItem<T>(T menuItem, IDataService<List<T>> dataService) where T : MenuItem
        {
            List<T> items = dataService.ReadJson() ?? new List<T>();
            items.Add(menuItem);
            dataService.WriteJson(items);
        }

        public Menu GetMenu()
        {
            List<Dish> dishes = _dishDataService.ReadJson() ?? new List<Dish>();
            List<Drink> drinks = _drinkDataService.ReadJson() ?? new List<Drink>();

            Menu menu = new Menu();
            menu.Items.AddRange(dishes);
            menu.Items.AddRange(drinks);
            menu.Items.Sort();
            return menu;
        }

        public MenuItem GetMenuItemById(int id)
        {
            return GetMenu().Items.FirstOrDefault(item => item.Id == id);
        }
    }
}
