using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface ITableService
    {
        List<Table> GetTables();
        void SaveTables(List<Table> tables);
    }
}
