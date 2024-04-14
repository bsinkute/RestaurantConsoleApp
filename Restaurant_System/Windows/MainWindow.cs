using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class MainWindow
    {
        private readonly EmployeeWindow _employeeWindow;

        public MainWindow(EmployeeWindow employeeWindow)
        {
            _employeeWindow = employeeWindow;
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
            Console.Clear();
            Console.Write("Enter your identification number: ");
            Console.ReadLine();
            Employee employee = new Employee(1, "Ana");
            _employeeWindow.Load(employee);
        }
    }
}
