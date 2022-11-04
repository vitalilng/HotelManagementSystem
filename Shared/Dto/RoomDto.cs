namespace HotelManagementSystem.Shared.Dto
{
    public class RoomDto
    {
        public DateTime CheckinStartDate { get; set; }
        public DateTime CheckinEndDate { get; set; }
        public int Sleeps { get; set; }  //nrOfPersons that can sleep
        public string? Type { get; set; }
        public int Price { get; set; }
        public string? AvailabilityStatus { get; set; }
    }
}
