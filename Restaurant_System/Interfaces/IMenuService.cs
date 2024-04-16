using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IMenuService
    {
        Menu GetMenu();
        void AddMenuItem(MenuItem menuItem);
    }
}
