using Microsoft.AspNetCore.Mvc;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Models;

namespace StockMarket_begum.Controllers
{
    public class StockController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()

        {
            var stockPortfolios = await _unitOfWork.StockRepository.GetStockAsync();
            return Ok(stockPortfolios);

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Stock>>> AddStock(Stock stock)
        {
            if (ModelState.IsValid)
            {
                // Add the new portfolio to the database
                // Assuming the repository has an AddPortfolioAsync method
                await _unitOfWork.StockRepository.AddStockAsync(stock);
                return RedirectToAction("Index");
            }

            return View(stock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStockPortfolios(string id, Stock updatedStock)
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

                return RedirectToAction("Index");
            }

            // If the model is not valid, return the view with errors
            return View(updatedStock);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteStockPortfolios(string id)
        {
            var stock = await _unitOfWork.StockRepository.GetStockByIdAsync(id);
            if (stock == null)
            {
                return BadRequest();
            }
            await _unitOfWork.StockRepository.DeleteStockAsync(id);
            return View(stock);
        }


    }
}
