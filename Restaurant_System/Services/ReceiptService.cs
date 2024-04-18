using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;
using System.Text;

namespace RestaurantSystem.Services
{
    public class ReceiptService : IReceiptService
    {
        public string GetReceipt(Order order, bool isRestaurantReceipt)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order object cannot be null.");
            }

            StringBuilder receiptBuilder = new StringBuilder();

            receiptBuilder.AppendLine("========== Order Receipt ==========");
            receiptBuilder.AppendLine($"Order ID: {order.OrderId}");
            receiptBuilder.AppendLine($"Employee ID: {order.EmployeeId}");

            if (isRestaurantReceipt)
            {
                receiptBuilder.AppendLine($"Table ID: {order.TableId}");
                receiptBuilder.AppendLine($"Number of Guests: {order.NumberOfPeople}");
                receiptBuilder.AppendLine($"Date check in: {order.Checkin}");
            }
            
            receiptBuilder.AppendLine($"Date check out: {order.Checkout}");
            receiptBuilder.AppendLine("\r\nOrdered Items:");
            foreach (OrderItem item in order.Items)
            {
                receiptBuilder.AppendLine($" - {item.Quantity}x {item.OrderedItem.Name} {item.OrderedItem.Price:N} € each");
            }
            receiptBuilder.AppendLine($"Price:");
            receiptBuilder.AppendLine($"Price with VAT: {order.TotalAmountVatIncluded():N} €");
            receiptBuilder.AppendLine($"Price without VAT: {order.TotalAmountWithoutVat():N} €");
            receiptBuilder.AppendLine($"VAT (21%): {order.VatAmount():N} €");
            receiptBuilder.AppendLine("===================================");

            return receiptBuilder.ToString();
        }
    }
}
