using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.Dto
{
    public class RoomDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Room Type is a required field.")]
        public string? RoomType { get; set; }
        
        [Required(ErrorMessage = "Room Size is a required field.")]
        public string? RoomSize { get; set; }

        [Required(ErrorMessage = "NrOfBedsAndSizes is a required field.")]
        public string? NrOfBedsAndSizes { get; set; }

        [Required(ErrorMessage = "RoomOptions is a required field.")]
        public string? RoomOptions { get; set; }

        [Required(ErrorMessage = "MaxPersonsAllowed is a required field.")]
        public string? MaxPersonsAllowed { get; set; }

        [Required(ErrorMessage = "Availability is a required field.")]
        public string? Availability { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is a required field.")]
        public int Price { get; set; }
    }
}
