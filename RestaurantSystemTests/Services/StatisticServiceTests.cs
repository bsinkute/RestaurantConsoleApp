using RestaurantSystem.Models;
using RestaurantSystem.Services;

namespace RestaurantSystemTests.Services
{
    public class StatisticServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private List<Order> GenerateSampleOrders()
        {
            var menu = new Menu();
            var menuItem1 = new MenuItem(1, "Pizza", 12.99m, DateTime.Now);
            var menuItem2 = new MenuItem(2, "Salad", 8.99m, DateTime.Now);
            menu.Items.Add(menuItem1);
            menu.Items.Add(menuItem2);

            var order1 = new Order
            {
                OrderId = 1,
                NumberOfPeople = 2,
                TableNumberOfSeats = 4,
                Items = new List<OrderItem>
                {
                    new OrderItem { OrderedItem = menuItem1, Quantity = 1 },
                    new OrderItem { OrderedItem = menuItem2, Quantity = 2 }
                }
            };

            var order2 = new Order
            {
                OrderId = 2,
                NumberOfPeople = 4,
                TableNumberOfSeats = 6,
                Items = new List<OrderItem>
                {
                    new OrderItem { OrderedItem = menuItem1, Quantity = 2 }
                }
            };

            return new List<Order> { order1, order2 };
        }

        [Test]
        public void GetTotalRevenueWithVat_ValidOrders_ReturnsCorrectValue()
        {
            // Arrange
            var orders = GenerateSampleOrders();
            var statisticService = new StatisticService(null);

            // Act
            var totalRevenueWithVat = statisticService.GetTotalRevenueWithVat(orders);

            // Assert
            Assert.AreEqual(12.99m + (2 * 8.99m) + (2 * 12.99m), totalRevenueWithVat);
        }

        [Test]
        public void GetTotalRevenueWithoutVat_ValidOrders_ReturnsCorrectValue()
        {
            // Arrange
            var orders = GenerateSampleOrders();
            var statisticService = new StatisticService(null);

            var expectedTotalAmount1 = (1 * 12.99m) + (2 * 8.99m); // 30.97
            var expectedTotalAmount2 = (2 * 12.99m); // 25.98
            var expectedTotalAmountWithoutVat = (expectedTotalAmount1 + expectedTotalAmount2) * 0.79m;

            // Act
            var totalRevenueWithoutVat = statisticService.GetTotalRevenueWithoutVat(orders);

            // Assert
            Assert.AreEqual(expectedTotalAmountWithoutVat, totalRevenueWithoutVat);
        }

        [Test]
        public void TimesTablesNotFull_ValidOrders_ReturnsCorrectCount()
        {
            // Arrange
            var orders = GenerateSampleOrders();
            var statisticService = new StatisticService(null);

            // Act
            var timesTablesNotFull = statisticService.TimesTablesNotFull(orders);

            // Assert
            Assert.AreEqual(2, timesTablesNotFull);
        }

        [Test]
        public void GetTotalCustomers_ValidOrders_ReturnsCorrectValue()
        {
            // Arrange
            var orders = GenerateSampleOrders();
            var statisticService = new StatisticService(null);

            // Act
            var totalCustomers = statisticService.GetTotalCustomers(orders);

            // Assert
            Assert.AreEqual(2 + 4, totalCustomers);
        }

        [Test]
        public void GetTotalSeats_ValidOrders_ReturnsCorrectValue()
        {
            // Arrange
            var orders = GenerateSampleOrders();
            var statisticService = new StatisticService(null);

            // Act
            var totalSeats = statisticService.GetTotalSeats(orders);

            // Assert
            Assert.AreEqual(4 + 6, totalSeats);
        }
    }
}
