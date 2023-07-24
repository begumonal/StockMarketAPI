using StockMarket_begum.Models;

namespace StockMarket_begum.Coe.Repository
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionAsync();
        Task<Transaction> GetTransactionByIdAsync(string id);
        Task AddTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(string id);
        Task UpdateTransactionAsync(string id, Transaction transaction);
    }
}
