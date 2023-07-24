
namespace StockMarket_begum.Coe.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        ITransactionRepository TransactionRepository { get; }
        IStockBehaviourRepository StockBehaviourRepository { get; }
        IStockRepository StockRepository { get; }
        IPortfolioRepository PortfolioRepository { get; }

    }
}
