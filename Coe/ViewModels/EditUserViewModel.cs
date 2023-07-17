using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockMarket_begum.Models;

namespace StockMarket_begum.Coe.ViewModels
{
    public class EditUserViewModel
    {
        public CustomUser User { get; set; }
        public IList<SelectListItem> Roles { get; set;}
    }
}
