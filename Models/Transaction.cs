using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StockMarket_begum.Models
{
    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; }

        [Required]
        public string StockId { get; set; }


        [Required]
        public string UserId { get; set; }

        [Required]
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public Stock Stock { get; set; }

        public List<StockBehaviour> StockBehaviours { get; set; } = new();

        public CustomUser User { get; set; }



        public Transaction()
        {
            UserId = "0";
            TransactionId = "0";
            StockId = "0";
            Type = "";
            Date = DateTime.Now;
            Price = 0;
        }

        public Transaction(string transactionId,string customUserId, string stockId, string type, DateTime date, decimal price, Stock stock)
        {
            UserId = customUserId;
            TransactionId = transactionId;
            StockId = stockId;
            Type = type;
            Date = date;
            Price = price;
            Stock = stock;
        }
    }

    
}
