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
            Console.ReadLine();
        }

    }
}
