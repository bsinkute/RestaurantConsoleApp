using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class TakeOrderWindow
    {
        public void Load()
        {
            Console.Clear();
            List<Table> tables = new List<Table>();
            Table table1 = new Table(1, 5);
            Table table2 = new Table(2, 3);
            Table table3 = new Table(3, 2);
            tables.Add(table1);
            tables.Add(table2);
            tables.Add(table3);
            Console.WriteLine("Tables:");
            foreach (Table table in tables)
            {
                Console.WriteLine(table);
            }
            Console.Write("Enter the Id of the table at which you want customers to sit: ");
            string input = Console.ReadLine();
            bool isValidNumber = int.TryParse(input, out int tableId);
            bool tableExists = tables.Any(table => table.Id == tableId);

            while (!isValidNumber || !tableExists)
            {
                if (!isValidNumber)
                {
                    Console.Write("Invalid input. Please enter a valid table Id: ");
                }
                else if (!tableExists)
                {
                    Console.Write($"Table with Id {tableId} does not exist. Enter a valid table Id: ");
                }
                input = Console.ReadLine();
                isValidNumber = int.TryParse(input, out tableId);
                tableExists = tables.Any(table => table.Id == tableId);
            }
            Table selectedTable = tables.FirstOrDefault(t => t.Id == tableId);
            Console.WriteLine($"Table {tableId} selected. Number of seats: {selectedTable.NumberOfSeats}");
        }

    }
}
