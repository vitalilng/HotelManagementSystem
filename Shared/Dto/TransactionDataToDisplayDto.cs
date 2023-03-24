namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataToDisplayDto
    {
        public RoomDto? Room { get; set; }
        private double totalSum;
        public string? UserName { get; set; }
        public string? RoomType { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
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
        public DateTimeOffset TransactionDateTime { get; set; }
    }
}
