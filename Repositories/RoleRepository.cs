using Microsoft.AspNetCore.Identity;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Data;

namespace StockMarket_begum.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {   
            _context = context;
        }
        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
