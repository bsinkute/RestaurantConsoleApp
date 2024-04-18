using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;
using System.Collections.Generic;

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
            List<Order> dailyOrders = _orderService.GetDayOrders(DateTime.Now);
            Console.WriteLine("Revenue: ");
            Console.WriteLine($"With VAT: {_statisticService.GetTotalRevenueWithVat(dailyOrders)} €");
            Console.ReadLine();
        }

    }
}
