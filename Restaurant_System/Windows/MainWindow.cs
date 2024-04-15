using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class MainWindow
    {
        private readonly EmployeeWindow _employeeWindow;
        private readonly IEmployeeService _employeeService;

        public MainWindow(EmployeeWindow employeeWindow, IEmployeeService employeeService)
        {
            _employeeWindow = employeeWindow;
            _employeeService = employeeService;
        }

        public void Load()
        {
            while (true)
            {
                DisplayMenu();
                bool isLoadCorect = int.TryParse(Console.ReadLine(), out int loadSelect);
                while (!isLoadCorect || loadSelect < 1 || loadSelect > 2)
                {
                    Console.Write("Please enter a number from 1 to 2: ");
                    isLoadCorect = int.TryParse(Console.ReadLine(), out loadSelect);
                }
                if (loadSelect == 1)
                {
                    EmployeeLogin();
                }
                else break;
            }
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to restaurant system!");
            Console.WriteLine("1. Login \r\n2. Exit");
            Console.Write("Enter number from 1 to 2: ");
        }

        public void EmployeeLogin()
        {
            List<Employee> employees = _employeeService.GetEmployees();
            Console.Clear();
            Console.WriteLine("Employees list:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.Write("Enter your identification number: ");
            bool isChoiseCorrect = int.TryParse(Console.ReadLine(), out int choise);
            bool employeeExist = employees.Any(employees => employees.Id == choise);
            while (!isChoiseCorrect || !employeeExist)
            {
                if (!isChoiseCorrect)
                {
                    Console.Write("Invalid input. Please enter a valid employee Id: ");
                }
                else if (!employeeExist)
                {
                    Console.Write($"Employee with Id {choise} does not exist. Enter a valid employee Id: ");
                }
                isChoiseCorrect = int.TryParse(Console.ReadLine(), out choise);
                employeeExist = employees.Any(employees => employees.Id == choise);
            }

            Employee selectedEmployee = employees.FirstOrDefault(employee => employee.Id == choise);
            _employeeWindow.Load(selectedEmployee);
        }
    }
}
