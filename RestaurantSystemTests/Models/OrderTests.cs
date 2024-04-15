using RestaurantSystem.Models;

namespace RestaurantSystemTests.Models
{
    public class OrderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TotalAmountVatIncluded_CalculateTotalPrice()
        {
            //Arrange
            var order = new Order(2, DateTime.Now, 2, 5, 1);
            var pizza = new Dish(1, "Pizza", 12.55m);
            var fanta = new Drink(2, "Fanta", 2.50m);
            decimal expectedPrice = 30.10m;

            //Act
            order.AddOrderItem(pizza, 2);
            order.AddOrderItem(fanta, 2);
            var totalPrice = order.TotalAmountVatIncluded();

            //Assert
            Assert.AreEqual(expectedPrice, totalPrice);
        }


        [Test]
        public void VatAmount_CalculateVatAmount()
        {
            //Arrange
            var order = new Order(2, DateTime.Now, 2, 5, 1);
            var pizza = new Dish(1, "Pizza", 12.55m);
            var fanta = new Drink(2, "Fanta", 2.50m);
            decimal expectedVat = 6.321m;

            //Act
            order.AddOrderItem(pizza, 2);
            order.AddOrderItem(fanta, 2);
            var vat = order.VatAmount();

            //Assert
            Assert.AreEqual(expectedVat, vat);
        }

        [Test]
        public void TotalAmountWithoutVat_CalculatePriceWithoutVat()
        {
            //Arrange
            var order = new Order(2, DateTime.Now, 2, 5, 1);
            var pizza = new Dish(1, "Pizza", 12.55m);
            var fanta = new Drink(2, "Fanta", 2.50m);
            decimal expectedPrice = 23.779m;

            //Act
            order.AddOrderItem(pizza, 2);
            order.AddOrderItem(fanta, 2);
            var totalPrice = order.TotalAmountWithoutVat();

            //Assert
            Assert.AreEqual(expectedPrice, totalPrice);
        }
    }
}