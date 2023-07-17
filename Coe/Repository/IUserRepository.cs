using StockMarket_begum.Models;


namespace StockMarket_begum.Coe.Repository
{
    public interface IUserRepository
    {
        ICollection<CustomUser> GetUsers();

        CustomUser GetUser(string id);

        CustomUser UpdateUser(CustomUser user);
    }
}