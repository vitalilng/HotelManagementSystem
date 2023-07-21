namespace HotelManagementSystem.Client.HttpRepository
{
    public class RoomHttpRepository : IRoomHttpRepository
    {
        private readonly HttpClient _httpClient;

        public RoomHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> UploadImages(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync("https://localhost:7269/api/upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                return Path.Combine("https://localhost:7269/", postContent);
            }
        }
    }
}