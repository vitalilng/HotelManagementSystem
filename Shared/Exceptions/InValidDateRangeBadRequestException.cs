namespace HotelManagementSystem.Shared.Exceptions
{
    public sealed class InValidDateRangeBadRequestException : BadRequestException
    {
        public InValidDateRangeBadRequestException()
            : base("Date of Departure should be higher than Date of Arrival!")
        {
        }

        public InValidDateRangeBadRequestException(string message) : base(message)
        {
        }
    }
}
