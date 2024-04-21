using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IEmployeeService
    {
        Employee Authenticate(string password);
    }
}
