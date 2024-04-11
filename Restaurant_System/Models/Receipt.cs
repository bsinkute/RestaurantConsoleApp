namespace RestaurantSystem.Models
{
    public class Receipt
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public Order Order { get; private set; }

        public Receipt(int id, DateTime date, Order order)
        {
            Id = id;
            Date = date;
            Order = order;
        }

        public decimal TotalAmountVatIncluded()
        {
            decimal totalAmount = 0;
            foreach (var item in Order.Items)
            {
                totalAmount += item.Quantity * item.OrderedProduct.Price;
            }
            return totalAmount;
        }
    }
}
