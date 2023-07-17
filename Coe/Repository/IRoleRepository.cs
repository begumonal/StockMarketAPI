using Microsoft.AspNetCore.Identity;

namespace StockMarket_begum.Coe.Repository
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
