namespace HotelManagementSystem.Server.Models
{
    /// <summary>
    /// Room Model
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Room Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Type - single, double, king, president
        /// </summary>
        public string? RoomType { get; set; }
        
        /// <summary>
        /// Size in square metters
        /// </summary>
        public string? RoomSize { get; set; }

        /// <summary>
        /// How many beds and their sizes
        /// </summary>
        public string? NrOfBedsAndSizes { get; set; }

        /// <summary>
        /// Internet, TV, wifi available, fridge and so on
        /// </summary>
        public string? RoomOptions { get; set; }

        /// <summary>
        /// How many persons are allowed
        /// </summary>
        public string? MaxPersonsAllowed { get; set; }

        /// <summary>
        /// Is the room available for booking
        /// </summary>
        public string? Availability { get; set; }

        /// <summary>
        /// Some description
        /// </summary>
        public string? Description{ get; set; }
        
        /// <summary>
        /// Room price
        /// </summary>
        public long Price { get; set; }

        /// <summary>
        /// Navigation property to transaction model
        /// </summary>
        public List<Transaction>? Transactions { get; set; }
    }
}
