using StockMarket_begum.Models;

namespace StockMarket_begum.Coe.Repository
{
    public interface IStockBehaviourRepository
    {
        Task<IEnumerable<StockBehaviour>> GetStockBehaviourAsync();
        Task<StockBehaviour> GetStockBehaviourByIdAsync(string id);
        Task AddStockBehaviourAsync(StockBehaviour stockBehaviour);
        Task DeleteStockBehaviourAsync(string id);
        Task UpdateStockBehaviourAsync(string id, StockBehaviour stockBehaviour);
    }
}
