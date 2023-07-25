using Microsoft.EntityFrameworkCore;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Data;
using StockMarket_begum.Models;

namespace StockMarket_begum.Repositories
{
    public class StockBehaviourRepository : IStockBehaviourRepository
    {
        private readonly ApplicationDbContext _context;

        public StockBehaviourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddStockBehaviourAsync(StockBehaviour stockBehaviour)
        {
            _context.StockBehaviours.Add(stockBehaviour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStockBehaviourAsync(string id)
        {
            var stock = await _context.StockBehaviours.FirstOrDefaultAsync(s => s.StockBehaviourId == id);
            if (stock != null)
            {
                _context.StockBehaviours.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StockBehaviour>> GetStockBehaviourAsync()
        {
            return await _context.StockBehaviours.ToListAsync();
        }

        public async Task<StockBehaviour> GetStockBehaviourByIdAsync(string id)
        {
            return await _context.StockBehaviours.FirstOrDefaultAsync(s => s.StockBehaviourId == id);
        }

        public async Task UpdateStockBehaviourAsync(string id, StockBehaviour stockBehaviour)
        {
            _context.Entry(stockBehaviour).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
