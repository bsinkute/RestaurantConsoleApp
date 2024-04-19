using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace RestaurantSystem.Windows
{
    public class DailyStatisticsWindow
    {
        private readonly IStatisticService _statisticService;
        private readonly IOrderService _orderService;

        public DailyStatisticsWindow(IStatisticService statisticService, IOrderService orderService)
        {
            _statisticService = statisticService;
            _orderService = orderService;
        }
        public void Load()
        {
            Console.Clear();
            List<Order> dailyOrders = _orderService.GetDayOrders(DateTime.Now);
            Console.WriteLine("Revenue: ");
            Console.WriteLine($"With VAT: {_statisticService.GetTotalRevenueWithVat(dailyOrders)} €");

            var addedProducts = _statisticService.GetAddedProduct(DateTime.Now);

            Console.WriteLine("Today's Added Menu Items:");
            foreach (var product in addedProducts)
            {
                Console.WriteLine($"- Name: {product.Name}, Price: {product.Price:N} €");
            }
            Console.ReadLine();
        }

    }
}
