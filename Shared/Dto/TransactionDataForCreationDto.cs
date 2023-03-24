namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataForCreationDto
    {
        public RoomDto Room { get; set; }
        private int totalSum;
        private DateTime? arrivalDate;
        private DateTime? departureDate;

        public TransactionDataForCreationDto(RoomDto roomDto)
        {
            Room = roomDto ?? throw new ArgumentNullException(nameof(roomDto));
            SetTotalSum();
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
        public DateTime? ArrivalDate
        {
            get => arrivalDate;
            set
            {
                arrivalDate = value;
                SetTotalSum();
            }
        }

        /// <summary>
        /// booking end date
        /// </summary>
        public DateTime? DepartureDate
        {
            get => departureDate;
            set
            {
                departureDate = value;
                SetTotalSum();
            }
        }

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
