using RestaurantSystem.Infrastructure;
using RestaurantSystem.Models;
using RestaurantSystem.Services;

namespace RestaurantSystemTests.Services
{
    public class OrderServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddOrder_FirstOrder_OrderIdIsOne()
        {
            // Arrange
            var orderDataService = new TestDataServiceImpl<List<Order>>();
            var orderService = new OrderService(orderDataService);

            var order = new Order
            {
                NumberOfPeople = 4,
                Checkin = DateTime.Now,
                Checkout = DateTime.Now.AddHours(2),
                TableId = 1,
                TableNumberOfSeats = 4,
                EmployeeId = 1
            };

            // Act
            orderService.AddOrder(order);

            // Assert
            Assert.AreEqual(1, order.OrderId);
        }

        [Test]
        public void AddOrder_SecondOrder_OrderIdIsIncremented()
        {
            // Arrange
            var existingOrders = new List<Order>
            {
                new Order { OrderId = 1, NumberOfPeople = 2, Checkin = DateTime.Now, Checkout = DateTime.Now.AddHours(1), TableId = 2, TableNumberOfSeats = 2, EmployeeId = 1 },
                new Order { OrderId = 2, NumberOfPeople = 3, Checkin = DateTime.Now, Checkout = DateTime.Now.AddHours(2), TableId = 3, TableNumberOfSeats = 6, EmployeeId = 2 }
            };

            var orderDataService = new TestDataServiceImpl<List<Order>>();
            orderDataService.WriteJson(existingOrders);

            var orderService = new OrderService(orderDataService);

            var newOrder = new Order
            {
                NumberOfPeople = 5,
                Checkin = DateTime.Now,
                Checkout = DateTime.Now.AddHours(3),
                TableId = 4,
                TableNumberOfSeats = 8,
                EmployeeId = 1
            };

            // Act
            orderService.AddOrder(newOrder);

            // Assert
            Assert.AreEqual(3, newOrder.OrderId);
        }

        [Test]
        public void AddMenuItemToOrder_NewOrderItem_AddsNewItem()
        {
            // Arrange
            var orderDataService = new TestDataServiceImpl<List<Order>>();
            var orderService = new OrderService(orderDataService);

            var menuItem = new MenuItem(1, "Pizza", 12.99m, DateTime.Now);
            var order = new Order { OrderId = 1, Items = new List<OrderItem>() };

            // Act
            orderService.AddOrder(order);
            orderService.AddMenuItemToOrder(order.OrderId, menuItem, 2);

            // Assert
            var savedOrders = orderDataService.ReadJson();
            var updatedOrder = savedOrders.FirstOrDefault(o => o.OrderId == order.OrderId);
            Assert.NotNull(updatedOrder);
            Assert.AreEqual(1, updatedOrder.Items.Count);

            var orderItem = updatedOrder.Items.First();
            Assert.AreEqual(menuItem, orderItem.OrderedItem);
            Assert.AreEqual(2, orderItem.Quantity);
        }

        [Test]
        public void AddMenuItemToOrder_ExistingOrderItem_IncrementsQuantity()
        {
            // Arrange
            var menuItem = new MenuItem(1, "Pizza", 12.99m, DateTime.Now);
            var orderItem = new OrderItem { OrderedItem = menuItem, Quantity = 3 };
            var order = new Order { OrderId = 1, Items = new List<OrderItem> { orderItem } };
            var orderDataService = new TestDataServiceImpl<List<Order>>();
            var orderService = new OrderService(orderDataService);

            // Act
            orderService.AddOrder(order);
            orderService.AddMenuItemToOrder(order.OrderId, menuItem, 2);

            // Assert
            var savedOrders = orderDataService.ReadJson();
            var updatedOrder = savedOrders.FirstOrDefault(o => o.OrderId == order.OrderId);
            var updatedOrderItem = updatedOrder.Items.First();
            Assert.AreEqual(menuItem, updatedOrderItem.OrderedItem);
            Assert.AreEqual(5, updatedOrderItem.Quantity);
        }

        public class TestDataServiceImpl<T> : IDataService<T>
        {
            private T _data;

            public void WriteJson(T data)
            {
                _data = data;
            }

            public T ReadJson()
            {
                return _data;
            }

            public string FileName { get; set; }
        }
    }
}
