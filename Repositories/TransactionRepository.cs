using Microsoft.EntityFrameworkCore;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Data;
using StockMarket_begum.Models;

namespace StockMarket_begum.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        { 
            _context = context;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(string id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(string id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task UpdateTransactionAsync(string id, Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
