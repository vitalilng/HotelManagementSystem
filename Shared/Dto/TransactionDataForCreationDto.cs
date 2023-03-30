namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataForCreationDto
    {
        public double _totalSum;

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

        public int RoomPrice { get; set; }

        /// <summary>
        /// Transaction sum
        /// </summary>
        public double TotalSum
        {
            get
            {                
                if (DepartureDate is not null && ArrivalDate is not null)
                {
                    var nrOfDays = ((DateTime)DepartureDate - (DateTime)ArrivalDate).TotalDays;
                    _totalSum = (int)(RoomPrice * nrOfDays); //calculate the total sum                
                }
                return _totalSum;
            }            
        }
    }
}
