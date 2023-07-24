using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Data;
using StockMarket_begum.Models;

namespace StockMarket_begum.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }
        public IPortfolioRepository PortfolioRepository { get; }
        public IStockRepository StockRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public IStockBehaviourRepository StockBehaviourRepository { get;  }

        public UnitOfWork(ApplicationDbContext context, IUserRepository user, IRoleRepository role, IPortfolioRepository portfolio, IStockRepository stockportfolio, ITransactionRepository transaction, IStockBehaviourRepository stockbehaviour)
        {
            
            _context = context;  
          User = user;
          Role = role;
          PortfolioRepository = portfolio;
          StockRepository = stockportfolio;
          TransactionRepository = transaction;
          StockBehaviourRepository = stockbehaviour;

        }


        public UnitOfWork(IUserRepository user, IRoleRepository role)
        {
            User = user;
            Role = role;
        }

        private UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            PortfolioRepository = new PortfolioRepository(_context);
            StockRepository = new StockRepository(_context);
            TransactionRepository = new TransactionRepository(_context);
            StockBehaviourRepository = new StockBehaviourRepository(_context);
        }
    }
}