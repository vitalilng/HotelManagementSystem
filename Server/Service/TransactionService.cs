using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
using HotelManagementSystem.Shared.Exceptions;

namespace HotelManagementSystem.Server.Service
{
    /// <summary>
    /// Transaction Service
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;

        /// <summary>
        /// Transaction Service constructor
        /// </summary>
        /// <param name="loggerManager"></param>
        /// <param name="mapper"></param>
        /// <param name="repositoryManager"></param>
        public TransactionService(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }

        /// <summary>
        /// Get all transactions
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<TransactionDto> GetTransactions()
        {            
            var transactions = _repositoryManager.TransactionRepository.GetTransactionsEnumerable();
            var transactionsDto = _mapper.Map<IEnumerable<TransactionDto>>(transactions);
            return transactionsDto;
        }

        /// <summary>
        /// Get all transactions for displaying to UI
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<TransactionDataToDisplayDto> GetTransactionsToBeDisplayed()
        {
            var transactions = _repositoryManager.TransactionRepository.GetTransactionsQuerable().ProjectTo<TransactionDataToDisplayDto>(_mapper.ConfigurationProvider);
            var transactionsToDisplayDto = _mapper.Map<IEnumerable<TransactionDataToDisplayDto>>(transactions);
            return transactionsToDisplayDto;
        }

        /// <summary>
        /// Get bookings by username
        /// </summary>        
        /// <param name="username"></param>
        /// <returns></returns>
        public IEnumerable<TransactionDataToDisplayDto> GetTransactionsByUsername(string username)
        {            
            var transactions = _repositoryManager.TransactionRepository.GetTransactionsQuerable();
            var transactionDataToDisplay = transactions
                                                .Where(t => t.ApplicationUser != null && t.Room != null && t.ApplicationUser.UserName == username)                                                
                                                .Select(t => new
            {
                t.ApplicationUser.UserName, 
                t.Room.RoomType,
                t.ArrivalDate,
                t.DepartureDate,
                t.Room.Price,
                t.TotalSum,
                t.TransactionDateTime 
              });

            TransactionDataToDisplayDto transactionDto = new();

            foreach (var transaction in transactionDataToDisplay)
            {
                transactionDto = new()
                {
                    UserName = transaction.UserName,
                    RoomType = transaction.RoomType,
                    ArrivalDate = transaction.ArrivalDate,
                    DepartureDate = transaction.DepartureDate,
                    RoomPrice = transaction.Price,
                    TotalSum = transaction.TotalSum,
                    TransactionDateTime = transaction.TransactionDateTime
                };
            }

            yield return transactionDto;
        }


        /// <summary>
        /// Get transaction by Id
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TransactionDto GetTransaction(Guid transactionId)
        {
            var transaction = _repositoryManager.TransactionRepository.GetTransaction(transactionId) ?? throw new TransactionNotFoundException(transactionId);
            var transactionDto = _mapper.Map<TransactionDto>(transaction);
            return transactionDto;
        }

        /// <summary>
        /// Create new transaction
        /// </summary>
        /// <param name="transactionCreateDataDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TransactionDto CreateTransaction(TransactionDataForCreationDto transactionCreateDataDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionCreateDataDto);
            _repositoryManager.TransactionRepository.CreateTransaction(transaction);
            _repositoryManager.Save();

            var transactionToReturn = _mapper.Map<TransactionDto>(transaction);
            return transactionToReturn;
        }

        /// <summary>
        /// Update transaction
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="transactionUpdateDataDto"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateTransaction(Guid transactionId, TransactionDataForUpdateDto transactionUpdateDataDto)
        {
            var transactionToBeUpdated = _repositoryManager.TransactionRepository.GetTransaction(transactionId);
            if (transactionToBeUpdated is null)
            {
                throw new TransactionNotFoundException(transactionId);
            }
            _mapper.Map(transactionUpdateDataDto, transactionToBeUpdated); //Map(source, destination)
            _repositoryManager.TransactionRepository.UpdateTransaction(transactionToBeUpdated);
            _repositoryManager.Save();
        }

        /// <summary>
        /// Get transaction for patch update
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public (TransactionDataForUpdateDto transactionDataForUpdate, Transaction transaction) GetTransactionForPatch(Guid transactionId)
        {
            var transactionToBePatched = _repositoryManager.TransactionRepository.GetTransaction(transactionId) ?? throw new TransactionNotFoundException(transactionId);

            // here we map the transaction entity model we received from db
            // to the transaction update dto which will be modified on ui
            var transactionPatchDataDto = _mapper.Map<TransactionDataForUpdateDto>(transactionToBePatched);
            return (transactionPatchDataDto, transactionToBePatched);
        }

        /// <summary>
        /// Save patch changes
        /// </summary>
        /// <param name="transactionPatchDataDto"></param>
        /// <param name="transaction"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SaveChangesForPatch(TransactionDataForUpdateDto transactionPatchDataDto, Transaction transaction)
        {
            //here we map the data we receive from the dto(UI object) to the original transaction model
            //to be further saved in database
            _mapper.Map(transactionPatchDataDto, transaction);
            _repositoryManager.Save();
        }

        /// <summary>
        /// Delete transaction
        /// </summary>
        /// <param name="transactionId"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteTransaction(Guid transactionId)
        {
            var transactionToBeDeleted = _repositoryManager.TransactionRepository.GetTransaction(transactionId) ?? throw new TransactionNotFoundException(transactionId);
            _repositoryManager.TransactionRepository.DeleteTransaction(transactionToBeDeleted);
            _repositoryManager.Save();
        }          
    }
}
