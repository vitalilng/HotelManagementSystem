namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataForCreationDto
    {

        private int totalSum;
        public RoomDto Room { get; set; }
        public int TotalSum { get => totalSum; set => totalSum = value; }

        public TransactionDataForCreationDto(RoomDto roomDto)
        {
            Room = roomDto ?? throw new ArgumentNullException(nameof(roomDto));
            TotalSum = 0;
            //SetTotalSum();
        }

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
        public int GetTotalSum { get; }

        /// <summary>
        /// Transaction sum
        /// </summary>
        public void SetTotalSum()
        {
            if (Room == null)
            {
                throw new ArgumentNullException(nameof(Room));
            }
            totalSum = (int)(Room.Price * ((DateTime)DepartureDate - (DateTime)ArrivalDate).TotalDays); //calculate the total sum                
        }
    }
}
