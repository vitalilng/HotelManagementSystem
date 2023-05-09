using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataForCreationDto
    {
        public double _totalSum;

        [Required(ErrorMessage = "User id is required")]
        /// <summary>
        /// User id
        /// </summary>
        public string? ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Room id is required")]
        /// <summary>
        /// Room Id
        /// </summary>
        public Guid RoomId { get; set; }

        [Required(ErrorMessage = "Arrival date is required")]
        /// <summary>
        /// Booking start date
        /// </summary>
        public DateTime? ArrivalDate {get; set;}

        [Required(ErrorMessage ="Departure date is required")]
        /// <summary>
        /// booking end date
        /// </summary>
        public DateTime? DepartureDate { get; set; }

        [Required(ErrorMessage ="Room Price is required")]
        public int RoomPrice { get; set; }

        /// <summary>
        /// Transaction sum
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Total sum is required and cannot be 0")]
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
