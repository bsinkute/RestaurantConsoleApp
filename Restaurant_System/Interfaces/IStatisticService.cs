using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IStatisticService
    {
        decimal GetTotalRevenueWithVat(List<Order> orders);
        decimal GetTotalRevenueWithoutVat(List<Order> orders);
        List<MenuItem> GetAddedProduct(DateTime date);
    }
}
