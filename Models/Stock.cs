using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StockMarket_begum.Models
{
    public class Stock
    {

        [Key]
        public string StockId { get; set; }

        [Required]
        public string StockBehaviourId { get; set;}

        [Required]
        [Display(Name = "Company name")]
        public string Company_Name { get; set;}

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }

        public List<StockBehaviour> StockBehaviours { get; set; } = new();

        public Stock()
        {
            StockId = "0";
            StockBehaviourId = "0";
            Company_Name = "";
            Quantity = 0;
            Price = 0;
        }

        public Stock(string stockId, string stockBehaviourId, string company_Name, decimal price, decimal quantity)
        {
            StockId = stockId;
            StockBehaviourId = stockBehaviourId;
            Company_Name = company_Name;
            Price = price;
            Quantity = quantity;
        }
    }
}

