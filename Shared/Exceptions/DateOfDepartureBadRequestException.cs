namespace HotelManagementSystem.Shared.Exceptions
{
    public sealed class DateOfDepartureBadRequestException : BadRequestException
    {
        public DateOfDepartureBadRequestException()
            : base("Departure date cannot be before Arrival Date")
        {
        }
    }
}
