﻿using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantSystem.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IMenuService _menuService;

        public StatisticService(IMenuService menuService)
        {
            _menuService = menuService;
        }
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

        public List<MenuItem> GetAddedProduct(DateTime date)
        {
            return _menuService.GetMenu().Items.Where(item => item.AddedDate.Date == date.Date)
                .ToList();
        }
    }
}
