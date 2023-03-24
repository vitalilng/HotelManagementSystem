using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Shared.Dto;
using HotelManagementSystem.Shared.RequestFeatures;

namespace HotelManagementSystem.Server.Service.Contracts
{
    /// <summary>
    /// Transaction Service Interface
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Get all transactions from db
        /// </summary>
        /// <returns></returns>
        IEnumerable<TransactionDto> GetTransactions();

        /// <summary>
        /// Get transaction join with user and  rooms tables
        /// </summary>
        /// <returns></returns>
        IEnumerable<TransactionDataToDisplayDto> GetTransactionsToBeDisplayed();

        /// <summary>
        /// Return transactions by username
        /// </summary>        
        /// <param name="username"></param>
        /// <returns></returns>
        IEnumerable<TransactionDataToDisplayDto> GetTransactionsByUsername(string username);

        /// <summary>
        /// Get transaction by id
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        TransactionDto GetTransaction(Guid transactionId);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionDataForCreation"></param>
        /// <returns></returns>
        TransactionDto CreateTransaction(TransactionDataForCreationDto transactionDataForCreation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="transactionDataForUpdate"></param>
        void UpdateTransaction(Guid transactionId, TransactionDataForUpdateDto transactionDataForUpdate);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        void DeleteTransaction(Guid transactionId);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        (TransactionDataForUpdateDto transactionDataForUpdate, Transaction transaction) GetTransactionForPatch(Guid transactionId);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionDataForUpdate"></param>
        /// <param name="transaction"></param>
        void SaveChangesForPatch(TransactionDataForUpdateDto transactionDataForUpdate, Transaction transaction);

    }
}
