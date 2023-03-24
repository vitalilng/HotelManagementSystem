namespace HotelManagementSystem.Shared.Dto
{
    public class RoomDataForCreationDto
    {
        public string? RoomType { get; set; }

        public string? RoomSize { get; set; }

        public string? NrOfBedsAndSizes { get; set; }

        public string? RoomOptions { get; set; }

        public string? MaxPersonsAllowed { get; set; }

        public string? Availability { get; set; }

        public string? Description { get; set; }

        public long Price { get; set; }
    }
}
