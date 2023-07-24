using Microsoft.AspNetCore.Mvc;
using StockMarket_begum.Coe.Repository;
using StockMarket_begum.Models;
using StockMarket_begum.Repositories;
using System.Diagnostics;

namespace StockMarket_begum.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsAsync()

        {
            var transactions = await _unitOfWork.TransactionRepository.GetTransactionAsync();
            return Ok(transactions);

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Transaction>>> AddTransactions(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                // Add the new portfolio to the database
                // Assuming the repository has an AddPortfolioAsync method
                await _unitOfWork.TransactionRepository.AddTransactionAsync(transaction);
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(string id,Transaction updatedTransaction)  
        {
            if (id != updatedTransaction.TransactionId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // Update the portfolio in the database
                // Assuming the repository has an UpdatePortfolioAsync method
                await _unitOfWork.TransactionRepository.UpdateTransactionAsync(id, updatedTransaction);

                return RedirectToAction("Index");
            }

            // If the model is not valid, return the view with errors
            return View(updatedTransaction);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTransactions(string id)
        {
            var transaction = await _unitOfWork.TransactionRepository.GetTransactionByIdAsync(id);
            if (transaction == null)
            {
                return BadRequest();
            }
            await _unitOfWork.TransactionRepository.DeleteTransactionAsync(id);
            return View(transaction);
        }


    }
}