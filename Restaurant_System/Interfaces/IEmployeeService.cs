using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IEmployeeService
    {
        string GetName(int id);
        Employee Authenticate(string password);
    }
}
