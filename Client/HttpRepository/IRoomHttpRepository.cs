namespace HotelManagementSystem.Client.HttpRepository
{
    public interface IRoomHttpRepository
    {
        Task<string> UploadImages(MultipartFormDataContent content);
    }
}
