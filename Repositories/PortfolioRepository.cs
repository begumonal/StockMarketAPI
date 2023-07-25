using Microsoft.EntityFrameworkCore;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Data;
using StockMarket_begum.Models;

namespace StockMarket_begum.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {

        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPortfolioAsync(Portfolio portfolio)
        {
             _context.Portfolios.Add(portfolio);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePortfolioAsync(string id)
        {
            var portfolio = await _context.Portfolios.FirstOrDefaultAsync(p => p.PortfolioId == id);
            if (portfolio != null)
            {
                _context.Portfolios.Remove(portfolio);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Portfolio>> GetPortfolioAsync()
        {
            return await _context.Portfolios.ToListAsync();
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(string id)
        {
            return await _context.Portfolios.FirstOrDefaultAsync(p => p.PortfolioId == id);

        }

        public async Task UpdatePortfolioAsync(Portfolio portfolio)
        {
            _context.Entry(portfolio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
