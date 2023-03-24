namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataForUpdateDto
    {
        public RoomDto? Room { get; set; }
        private double totalSum;
        
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

        /// <summary>
        /// Transaction sum
        /// </summary>
        public double TotalSum 
        {
            get
            {
                if (Room == null)
                {
                    throw new ArgumentNullException(nameof(Room));
                }
                return Room.Price * (DepartureDate - ArrivalDate).TotalDays; //calculate the total sum                
            }
            set
            {
                totalSum = value;
            }
        }
    }
}
