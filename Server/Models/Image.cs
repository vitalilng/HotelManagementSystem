namespace HotelManagementSystem.Server.Models
{
    /// <summary>
    /// Image upload data
    /// </summary>
    public class Image
    {
        /// <summary>
        /// image id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// image data upload
        /// </summary>
        public string Base64Data { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
    }
}