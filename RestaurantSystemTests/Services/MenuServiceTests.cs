using RestaurantSystem.Infrastructure;
using RestaurantSystem.Models;
using RestaurantSystem.Services;

namespace RestaurantSystemTests.Services
{
    public class MenuServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddMenuItem_FirstItem_IdIsSetToOne()
        {
            // Arrange
            var dishDataService = new TestDataServiceImpl<List<Dish>>();
            var drinkDataService = new TestDataServiceImpl<List<Drink>>();
            var menuService = new MenuService(dishDataService, drinkDataService);
            var dish = new Dish(0, "Pasta", 10.99m, DateTime.Now);

            // Act
            menuService.AddMenuItem(dish);

            // Assert
            Assert.AreEqual(1, dish.Id);
        }

        [Test]
        public void AddMenuItem_SecondItem_IdIsIncremented()
        {
            // Arrange
            var dishDataService = new TestDataServiceImpl<List<Dish>>();
            var drinkDataService = new TestDataServiceImpl<List<Drink>>();
            var menuService = new MenuService(dishDataService, drinkDataService);

            var firstDish = new Dish(1, "Pizza", 12.99m, DateTime.Now);
            menuService.AddMenuItem(firstDish);

            var secondDish = new Dish(0, "Burger", 8.99m, DateTime.Now);

            // Act
            menuService.AddMenuItem(secondDish);

            // Assert
            Assert.AreEqual(2, secondDish.Id);
        }

        [Test]
        public void AddMenuItem_WithExistingItems_IdIsIncrementedCorrectly()
        {
            // Arrange
            var dishDataService = new TestDataServiceImpl<List<Dish>>();
            var drinkDataService = new TestDataServiceImpl<List<Drink>>();
            var menuService = new MenuService(dishDataService, drinkDataService);

            var existingDishes = new List<Dish>
            {
                new Dish(1, "Soup", 6.99m, DateTime.Now),
                new Dish(2, "Salad", 5.99m, DateTime.Now)
            };
            dishDataService.WriteJson(existingDishes);
            var newDish = new Dish(0, "Steak", 19.99m, DateTime.Now);

            // Act
            menuService.AddMenuItem(newDish);

            // Assert
            Assert.AreEqual(3, newDish.Id);
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
