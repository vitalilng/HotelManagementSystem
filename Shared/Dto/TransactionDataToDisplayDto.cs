namespace HotelManagementSystem.Shared.Dto
{
    public class TransactionDataToDisplayDto
    {
        public string? UserName { get; set; }
        public string? RoomType { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public double RoomPrice { get; set; }
        public double TotalSum { get; set; }
        public DateTimeOffset TransactionDateTime { get; set; }
    }
}
