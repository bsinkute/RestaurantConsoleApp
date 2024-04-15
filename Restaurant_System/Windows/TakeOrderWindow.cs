using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class TakeOrderWindow
    {
        public void Load()
        {
            List<Table> tables = new List<Table>();
            Table table1 = new Table(1, 5);
            Table table2 = new Table(2, 3);
            Order someOrder = new Order(1, DateTime.Now, 2, 3);
            table2.Occupy(someOrder);
            Table table3 = new Table(3, 2);
            tables.Add(table1);
            tables.Add(table2);
            tables.Add(table3);
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

            Order order = new Order(numberOfPeople, DateTime.Now, selectedTable.Id, selectedTable.NumberOfSeats);
            selectedTable.Occupy(order);

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
