namespace HotelManagementSystem.Shared.RequestFeatures
{
    public class TransactionParameters
    {
        public DateTime? DateOfArrival { get; set; }
        public DateTime? DateOfDeparture { get; set; }

        /// <summary>
        /// check that DepartureDate is greater than ArrivalDate
        /// </summary>        
        public bool ValidDateRange => DateOfDeparture > DateOfArrival;        
    }
}