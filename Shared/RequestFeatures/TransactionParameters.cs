using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.RequestFeatures
{
    public class TransactionParameters
    {
        [Required(ErrorMessage ="Arrival Date is required")]
        public DateTime? DateOfArrival { get; set; }

        [Required(ErrorMessage = "Departure Date is required")]
        public DateTime? DateOfDeparture { get; set; }

        /// <summary>
        /// check that DepartureDate is greater than ArrivalDate
        /// </summary>
        [Required(ErrorMessage ="Departure date cannot be less than Arrival date")]
        public bool ValidDateRange => DateOfDeparture > DateOfArrival;        
    }
}