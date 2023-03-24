namespace HotelManagementSystem.Server.Models
{
    /// <summary>
    /// Transactions model
    /// </summary>
    public class Transaction
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
        /// booking start date
        /// </summary>               
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// booking end date
        /// </summary>             
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Transaction sum
        /// </summary>
        public double TotalSum  { get; set; }

        /// <summary>
        /// Date and transaction time
        /// </summary>
        public DateTimeOffset TransactionDateTime { get; set; }

        /// <summary>
        /// Application user navigation property
        /// </summary>
        public ApplicationUser? ApplicationUser { get; set; }

        /// <summary>
        /// Room navigation property
        /// </summary>
        public Room? Room { get; set; }
    }
}