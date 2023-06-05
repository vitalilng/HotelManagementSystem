using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Data;
using HotelManagementSystem.Server.Models;

namespace HotelManagementSystem.Server.Repository
{
    /// <summary>
    /// Transaction repository implementation
    /// </summary>
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        /// <summary>
        /// Transaction repository implementation constructor
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public TransactionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        /// <summary>
        /// return transaction by id
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public Transaction GetTransaction(Guid transactionId) => FindByCondition(c => c.Id.Equals(transactionId)).SingleOrDefault();

        /// <summary>
        /// return all transactions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transaction> GetTransactionsEnumerable() => FindAll().OrderBy(t => t.TransactionDateTime).ToList();

        /// <summary>
        /// return all transactions queryable
        /// </summary>
        /// <returns></returns>
        public IQueryable<Transaction> GetTransactionsQueryable() => FindAll().OrderBy(t => t.TransactionDateTime);

        /// <summary>
        /// Create 
        /// </summary>
        /// <param name="transaction"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void CreateTransaction(Transaction transaction) => Create(transaction);

        /// <summary>
        /// Delete transaction
        /// </summary>
        /// <param name="transaction"></param>
        public void DeleteTransaction(Transaction transaction) => Delete(transaction);
        
        /// <summary>
        /// Update transaction
        /// </summary>
        /// <param name="transaction"></param>
        public void UpdateTransaction(Transaction transaction) => Update(transaction);       
    }
}
