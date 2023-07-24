using Microsoft.AspNetCore.Mvc;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Models;

namespace StockMarket_begum.Controllers
{
    public class StockBehaviourController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockBehaviourController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockBehaviour>>> GetStockBehaviours()

        {
            var stockBehaviours = await _unitOfWork.StockBehaviourRepository.GetStockBehaviourAsync();
            return Ok(stockBehaviours);

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<StockBehaviour>>> AddStockBehaviours(StockBehaviour stockBehaviour)
        {
            if (ModelState.IsValid)
            {
                // Add the new portfolio to the database
                // Assuming the repository has an Add method
                await _unitOfWork.StockBehaviourRepository.AddStockBehaviourAsync(stockBehaviour);
                return RedirectToAction("Index");
            }

            return View(stockBehaviour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStockBehaviours(string id, StockBehaviour updatedStockBehaviour)
        {
            if (id != updatedStockBehaviour.StockBehaviourId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // Update the portfolio in the database
                // Assuming the repository has an Update method
                await _unitOfWork.StockBehaviourRepository.UpdateStockBehaviourAsync(id, updatedStockBehaviour);

                return RedirectToAction("Index");
            }

            // If the model is not valid, return the view with errors
            return View(updatedStockBehaviour);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteStockBehaviours(string id)
        {
            var stockBehaviour = await _unitOfWork.StockBehaviourRepository.GetStockBehaviourByIdAsync(id);
            if (stockBehaviour == null)
            {
                return BadRequest();
            }
            await _unitOfWork.StockBehaviourRepository.DeleteStockBehaviourAsync(id);
            return View(stockBehaviour);
        }
    }
}
