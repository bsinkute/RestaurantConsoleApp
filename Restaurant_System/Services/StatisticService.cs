using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services
{
    public class StatisticService : IStatisticService
    {
        public decimal GetTotalRevenueWithVat(List<Order> orders)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders), "Orders list cannot be null.");
            }

            return orders.Sum(x => x.TotalAmountVatIncluded());
        }

        public decimal GetTotalRevenueWithoutVat(List<Order> orders)
        {
            if (orders == null)
            {
                throw new ArgumentNullException(nameof(orders), "Orders list cannot be null.");
            }

            return orders.Sum(x => x.TotalAmountWithoutVat());
        }
    }
}
