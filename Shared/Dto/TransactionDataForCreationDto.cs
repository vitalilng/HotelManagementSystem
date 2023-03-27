namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataForCreationDto
    {

        private int totalSum;
        public RoomDto Room { get; set; }

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
        public DateTime? ArrivalDate {get; set;}


        /// <summary>
        /// booking end date
        /// </summary>
        public DateTime? DepartureDate { get; set; }

        /// <summary>
        /// Transaction sum
        /// </summary>
        public double TotalSum
        {
            get
            {
                if (Room != null && DepartureDate is not null && ArrivalDate is not null)
                {
                    return (int)(Room.Price * ((DateTime)DepartureDate - (DateTime)ArrivalDate).TotalDays); //calculate the total sum                
                }
                else
                {
                    throw new ArgumentNullException(nameof(Room));
                }
            }
        }
    }
}
