using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Server.Controllers
{
    /// <summary>
    /// Transactions controller
    /// </summary>
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        /// <summary>
        /// TransactionController constructor
        /// </summary>
        /// <param name="serviceManager"></param>
        public TransactionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Get all transactions
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTransactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTransactions()
        {
            var transactions = _serviceManager.TransactionService.GetTransactions();
            return Ok(transactions);
        }

        /// <summary>
        /// Transaction To be displayed in UI
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTransactionsToBeDisplayed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTransactionsToBeDisplayed()
        {
            var transactionsToBeDisplayed = _serviceManager.TransactionService.GetTransactionsToBeDisplayed();
            return Ok(transactionsToBeDisplayed);
        }

        /// <summary>
        /// Get bookings by username
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserTransactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUserTransactions(string username)
        {
            var userTransactions = _serviceManager.TransactionService.GetTransactionsByUsername(username);
            return Ok(userTransactions);
        }

        /// <summary>
        /// Get transaction by Id
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        [HttpGet("{transactionId}", Name = "TransactionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTransaction(Guid transactionId)
        {
            if (transactionId == Guid.Empty)
            {
                return NotFound($"{transactionId} was not found");
            }
            var transaction = _serviceManager.TransactionService.GetTransaction(transactionId);
            return Ok(transaction);
        }

        /// <summary>
        /// Create transaction
        /// </summary>
        /// <param name="transactionDataForCreation"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTransaction([FromBody] TransactionDataForCreationDto transactionDataForCreation)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            if (transactionDataForCreation is null)
            {
                return BadRequest("transactionDataForCreation object is null");
            }
            var createdTransaction = _serviceManager.TransactionService.CreateTransaction(transactionDataForCreation);
            return CreatedAtRoute("TransactionById", new { transactionId = createdTransaction.Id }, createdTransaction);
        }
    }
}