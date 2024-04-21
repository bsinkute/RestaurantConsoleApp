using RestaurantSystem.Infrastructure;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services
{
    public class TableService : ITableService
    {
        private readonly IDataService<List<Table>> _tableDataService;
        public TableService(IDataService<List<Table>> tableDataService)
        {
            _tableDataService = tableDataService;
        }
        public List<Table> GetTables()
        {
            List<Table> table = _tableDataService.ReadJson() ?? new List<Table>();
            return table;
        }

        public void SaveTables(List<Table> tables)
        {
            _tableDataService.WriteJson(tables);
        }
    }
}
