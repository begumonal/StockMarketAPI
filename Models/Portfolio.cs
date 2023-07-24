using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StockMarket_begum.Models
{
    public class Portfolio 
    {
        [Key]
        public string PortfolioId { get; set; }

        [Required]
        public string UserId { get; set;}

        [Required]
        public string StockId { get; set;}


        [Display(Name = "Company name")]    
        public string CompanyName { get; set; }

        [Display(Name = "Price")]
        public decimal StockPrice { get; set; }

        public CustomUser User { get; set; }

        public List<StockBehaviour> StockBehaviours { get; set; } = new();


        public Portfolio()
        {
            PortfolioId = "0";
            UserId = "0";
            StockId = "0"; ;
            CompanyName = "";
            StockPrice = 0;
        }

        public Portfolio(string portfolioid, string userid, string stockid, string companyname, decimal stockprice )
        {
            portfolioid = PortfolioId;
            userid = UserId;
            stockid = StockId;
            companyname = CompanyName;
            stockprice = StockPrice;
        }

    }
}
