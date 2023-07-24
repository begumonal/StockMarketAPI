using StockMarket_begum.Models;

namespace StockMarket_begum.Coe.Repository
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<Portfolio>> GetPortfolioAsync();
        Task<Portfolio> GetPortfolioByIdAsync(string id);
        Task  AddPortfolioAsync(Portfolio portfolio);
        Task DeletePortfolioAsync(string id);
        Task UpdatePortfolioAsync(Portfolio portfolio);

    }
}
