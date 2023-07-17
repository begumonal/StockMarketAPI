using StockMarket_begum.Models;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Data;

namespace StockMarket_begum.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public ICollection<CustomUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public CustomUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public CustomUser UpdateUser(CustomUser user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
    }

}