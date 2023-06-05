using HotelManagementSystem.Server.Models;

namespace HotelManagementSystem.Server.Contracts
{
    /// <summary>
    /// Transaction repository
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// Get all transactions
        /// </summary>
        IEnumerable<Transaction> GetTransactionsEnumerable();

        /// <summary>
        /// Get all transactions as querable
        /// </summary>
        IQueryable<Transaction> GetTransactionsQueryable();

        /// <summary>
        /// Get transaction
        /// </summary>
        Transaction GetTransaction(Guid transactionId);

        /// <summary>
        /// Create transaction
        /// </summary>
        /// <param name="transaction"></param>
        void CreateTransaction(Transaction transaction);

        /// <summary>
        /// update transaction
        /// </summary>
        /// <param name="transaction"></param>
        void UpdateTransaction(Transaction transaction);

        /// <summary>
        /// Delete transaction
        /// </summary>
        /// <param name="transaction"></param>
        void DeleteTransaction(Transaction transaction);
    }
}
