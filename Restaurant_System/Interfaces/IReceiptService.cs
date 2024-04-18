using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IReceiptService
    {
        string GetReceipt(Order order, bool isRestaurantReceipt);
        void AddReceipt(string receipt);
    }
}
