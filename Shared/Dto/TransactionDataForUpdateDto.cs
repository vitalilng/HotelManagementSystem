namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataForUpdateDto
    {        
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
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// bookind end date
        /// </summary>
        public DateTime DepartureDate { get; set; }

        public double RoomPrice { get; set; }

        /// <summary>
        /// Transaction sum
        /// </summary>
        public double TotalSum { get; set; }
    }
}
