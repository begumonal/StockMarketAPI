using StockMarket_begum.Repositories;
using StockMarket_begum.Models;

namespace StockMarket_begum.Coe.Repository
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStockAsync();
        Task<Stock> GetStockByIdAsync(string id);
        Task AddStockAsync(Stock stock);
        Task DeleteStockAsync(string id);
        Task UpdateStockAsync(string id, Stock stock);
    }
}
