namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDto
    {
        /// <summary>
        /// Transaction Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        public string? ApplicationUserId { get; set; }

        /// <summary>
        /// Room Id
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Booking start date
        /// </summary>
        public DateTime ArrivalDate   { get; set; }

        /// <summary>
        /// bookind departure date
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Transaction sum
        /// </summary>
        public double TotalSum { get; set; }

        /// <summary>
        /// date and time when transaction was made
        /// </summary>
        public DateTimeOffset TransactionDateTime { get; set; }
    }
}
