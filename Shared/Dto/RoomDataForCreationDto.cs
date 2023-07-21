using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.Dto
{
    public class RoomDataForCreationDto
    {
        [Required(ErrorMessage = "Room type is a required field.")]
        public string? RoomType { get; set; }

        [Required(ErrorMessage = "Room size is a required field.")]
        public string? RoomSize { get; set; }

        [Required(ErrorMessage = "Nr of beds and sizes is a required field.")]
        public string? NrOfBedsAndSizes { get; set; }

        [Required(ErrorMessage = "Room options is a required field.")]
        public string? RoomOptions { get; set; }

        [Required(ErrorMessage = "Max persons allowed is a required field.")]
        public string? MaxPersonsAllowed { get; set; }

        [Required(ErrorMessage = "Availability is a required field.")]
        public string? Availability { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is a required field.")]
        public long Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
