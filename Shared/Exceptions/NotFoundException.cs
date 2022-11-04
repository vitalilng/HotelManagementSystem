namespace HotelManagementSystem.Shared.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        /// <summary>
        /// this constructor will call the Exception.Exception(message)
        /// </summary>
        /// <param name="message"></param>
        protected NotFoundException(string message) : base(message)
        {
        }
    }
}