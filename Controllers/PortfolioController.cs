using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Repositories;
using StockMarket_begum.Models;

namespace StockMarket_begum.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PortfolioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portfolio>>> GetPortfolios( )

        {
            var portfolios = await _unitOfWork.PortfolioRepository.GetPortfolioAsync();
            return Ok(portfolios);
                
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Portfolio>>> AddPortfolios(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                // Add the new portfolio to the database
                // Assuming the repository has an AddPortfolioAsync method
                await _unitOfWork.PortfolioRepository.AddPortfolioAsync(portfolio);
                return RedirectToAction("Index");
            }

            return View(portfolio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePortfolios(string id, Portfolio updatedPortfolio)
        {
            if (id != updatedPortfolio.PortfolioId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // Update the portfolio in the database
                // Assuming the repository has an UpdatePortfolioAsync method
                await _unitOfWork.PortfolioRepository.UpdatePortfolioAsync(updatedPortfolio);

                return RedirectToAction("Index");
            }

            // If the model is not valid, return the view with errors
            return View(updatedPortfolio);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePorfolioAsync(string id)
        {
            var portfolio = await _unitOfWork.PortfolioRepository.GetPortfolioByIdAsync(id);
            if (portfolio == null)
            {
                return BadRequest();
            }

            await _unitOfWork.PortfolioRepository.DeletePortfolioAsync(id);
            return View(portfolio);
        }

       
    }
}
