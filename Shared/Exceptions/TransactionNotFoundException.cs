namespace HotelManagementSystem.Shared.Exceptions
{
    public sealed class TransactionNotFoundException : NotFoundException
    {
        /// <summary>
        /// this constructor will call NotFoundException.NotFoundException(message)
        /// </summary>
        /// <param name="userId"></param>
        public TransactionNotFoundException(Guid transactionId)
            : base($"The room with Id: {transactionId} doesn't exist in the database!")
        {
        }
    }
}
