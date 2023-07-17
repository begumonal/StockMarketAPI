
namespace StockMarket_begum.Coe.Repository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
    }
}
