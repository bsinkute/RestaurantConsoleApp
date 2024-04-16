using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class TakeOrderWindow
    {
        private readonly ITableService _tableService;
        private readonly IOrderService _orderService;

        public TakeOrderWindow(ITableService tableService, IOrderService orderService)
        {
            _tableService = tableService;
            _orderService = orderService;
        }
        public void Load(Employee employee)
        {
            List<Table> tables = _tableService.GetTables();
            Console.Clear();
            Console.Write("How many guests should be seated? ");
            bool isCorectNumber = int.TryParse(Console.ReadLine(), out int numberOfPeople);
            bool haveFittingTables = tables.Any(table => table.NumberOfSeats >= numberOfPeople);

            while (!isCorectNumber || numberOfPeople < 1 || !haveFittingTables)
            {
                if (!haveFittingTables)
                {
                    Console.Write("Sorry, we don't have a table that would suit you. if you want, you can split up at different tables.");
                    Console.ReadLine();
                    return;
                }
                Console.Write("Please enter a positive number: ");
                isCorectNumber = int.TryParse(Console.ReadLine(), out numberOfPeople);
            }

            Console.WriteLine("Tables:");
            foreach (Table table in tables)
            {
                Console.WriteLine(table);
            }
            Console.Write("Enter the Id of the table at which you want customers to sit: ");
            string input = Console.ReadLine();
            bool isValidNumber = int.TryParse(input, out int tableId);
            bool tableExists = tables.Any(table => table.Id == tableId);
            bool enoughSpace = tables.Any(table => table.Id == tableId && table.NumberOfSeats >= numberOfPeople);
            bool isTableFree = tables.Any(table => table.Id == tableId && table.IsFree());

            while (!isValidNumber || !tableExists || !enoughSpace || !isTableFree)
            {
                if (!isValidNumber)
                {
                    Console.Write("Invalid input. Please enter a valid table Id: ");
                }
                else if (!tableExists)
                {
                    Console.Write($"Table with Id {tableId} does not exist. Enter a valid table Id: ");
                }
                else if (!enoughSpace)
                {
                    Console.Write($"Table with Id {tableId} does not have enough seats. Choose a different table Id: ");
                }
                else if (!isTableFree)
                {
                    Console.Write($"Table with Id {tableId} is occupied. Choose a different table Id: ");
                }
                input = Console.ReadLine();
                isValidNumber = int.TryParse(input, out tableId);
                tableExists = tables.Any(table => table.Id == tableId);
                enoughSpace = tables.Any(table => table.Id == tableId && table.NumberOfSeats >= numberOfPeople);
                isTableFree = tables.Any(table => table.Id == tableId && table.IsFree());
            }
            Table selectedTable = tables.FirstOrDefault(t => t.Id == tableId);
            Console.WriteLine($"Table {tableId} selected. Number of seats: {selectedTable.NumberOfSeats}");

            Order order = new Order
            {
                NumberOfPeople = numberOfPeople,
                Checkin = DateTime.Now,
                TableId = selectedTable.Id,
                TableNumberOfSeats = selectedTable.NumberOfSeats,
                EmployeeId = employee.Id,
            };

            _orderService.AddOrder(order);
            selectedTable.Occupy(order);
            _tableService.SaveTables(tables);

            Console.Clear();
            Console.WriteLine("Tables:");
            foreach (Table table in tables)
            {
                Console.WriteLine(table);
            }
            Console.ReadLine();
            
        }

    }
}
