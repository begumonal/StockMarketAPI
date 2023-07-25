using Microsoft.AspNetCore.Mvc;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StockMarket_begum.Controllers
{
    public class StockController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey = "ZAJSDPDINFV3Y91Z";

        public StockController(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()

        {
            var stockPortfolios = await _unitOfWork.StockRepository.GetStockAsync();
            return Ok(stockPortfolios);

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Stock>>> AddStocks(Stock stock)
        {
            if (ModelState.IsValid)
            {
                // Add the new portfolio to the database
                // Assuming the repository has an AddPortfolioAsync method
                await _unitOfWork.StockRepository.AddStockAsync(stock);
            }

            return Ok(stock);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateStocks(string id, Stock updatedStock)
        {
            if (id != updatedStock.StockId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // Update the portfolio in the database
                // Assuming the repository has an UpdatePortfolioAsync method
                await _unitOfWork.StockRepository.UpdateStockAsync(id, updatedStock);

            }

            // If the model is not valid, return the view with errors
            return Ok(updatedStock);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteStocks(string id)
        {
            var stock = await _unitOfWork.StockRepository.GetStockByIdAsync(id);
            if (stock == null)
            {
                return BadRequest();
            }
            await _unitOfWork.StockRepository.DeleteStockAsync(id);
            return Ok(stock);
        }

        [HttpGet]
        public async Task<IActionResult> GetAlphaVantageData(string symbol)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var url =
                    $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_apiKey}";

                var response = await httpClient.GetAsync(url);  
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var stockData = JsonConvert.DeserializeObject<AlphaVantageStockData>(jsonString);
                    return Ok(stockData);
                }
            }

            return BadRequest();

        }
    }

    public class AlphaVantageStockData
    {
        public Dictionary<DateTime, AlphaVantageStockQuote> TimeSeriesDaily { get; set; }
    }

    public class AlphaVantageStockQuote
    {
        [JsonProperty("1. open")]
        public decimal Open { get; set; }

        [JsonProperty("2. high")]
        public decimal High { get; set; }

        [JsonProperty("3. low")]
        public decimal Low { get; set; }

        [JsonProperty("4. close")]
        public decimal Close { get; set; }
    }
}
