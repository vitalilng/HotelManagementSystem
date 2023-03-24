namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataForCreationDto
    {
        public RoomDto? Room { get; set; }
        private int totalSum;        

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
        /// booking end date
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Transaction sum
        /// </summary>
        public int GetTotalSum() => totalSum;

        /// <summary>
        /// Transaction sum
        /// </summary>
        public void SetTotalSum(int value)
        {
            if (Room == null)
            {
                throw new ArgumentNullException(nameof(Room));
            }
            totalSum = (int)(Room.Price * (DepartureDate - ArrivalDate).TotalDays); //calculate the total sum                
        }
    }
}
