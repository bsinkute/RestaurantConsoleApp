using RestaurantSystem.Infrastructure;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataService<List<Employee>> _employeeDataService;

        public EmployeeService(IDataService<List<Employee>> employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }

        public Employee Authenticate (string password) 
        {
            List<Employee> employees = _employeeDataService.ReadJson() ?? new List<Employee>();
            string hashedPasword = HashString(password);
            return employees.FirstOrDefault(x => x.Password == hashedPasword);
        }

        private static string HashString(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Convert byte to hexadecimal representation
                }
                return builder.ToString();
            }
        }
    }
}
