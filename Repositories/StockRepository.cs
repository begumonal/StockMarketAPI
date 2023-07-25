using Microsoft.EntityFrameworkCore;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Data;
using StockMarket_begum.Models;

namespace StockMarket_begum.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task AddStockAsync(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStockAsync(string id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.StockId == id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Stock>> GetStockAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock> GetStockByIdAsync(string id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.StockId == id);
        }

        public async Task UpdateStockAsync(string id, Stock stock)
        {
            _context.Entry(stock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
