using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using StockMarket_begum.Repositories;

namespace StockMarket_begum.Models
{
    public class StockBehaviour
    {

        [Key]
        public string StockBehaviourId { get; set; }

        [Required]
        public string StockId { get; set; }

        [Required]
        public string PortfolioId { get; set; }

        [Required]
        public string TransactionId { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Profitability value")]
        public decimal Profitabilitiy { get; set; }

        public Stock Stock { get; set; }
        public Portfolio Portfolio { get; set; }
        public Transaction Transaction { get; set; }

        public StockBehaviour()
        {
            StockBehaviourId = "0";
            Price = 0;
            Profitabilitiy = 0;
            Date = DateTime.Now;
        }

        public StockBehaviour(string portfolioId,string stockBehaviourId, string stockPortfolioId, DateTime date, decimal price, decimal profitabilitiy, Stock stock)
        {
            StockBehaviourId = stockBehaviourId;
            StockId = stockPortfolioId;
            PortfolioId = portfolioId;
            Date = date;
            Price = price;
            Profitabilitiy = profitabilitiy;
            Stock = stock;
        }
    }
}
