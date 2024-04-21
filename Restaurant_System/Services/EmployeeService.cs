using RestaurantSystem.Infrastructure;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataService<List<Employee>> _employeeDataService;

        public EmployeeService(IDataService<List<Employee>> employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _employeeDataService.ReadJson() ?? new List<Employee>();
            return employees;
        }
    }
}
