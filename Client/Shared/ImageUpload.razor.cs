using HotelManagementSystem.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace HotelManagementSystem.Client.Shared
{
    public partial class ImageUpload
    {
        [Parameter]
        public string? ImgUrl { get; set; }

        [Parameter]
        public EventCallback<string> OnChange { get; set; }

        [Inject]
        public IRoomHttpRepository? RoomHttpRepository { get; set; }

        private async Task UploadImages(InputFileChangeEventArgs e)
        {
            var imageFiles = e.GetMultipleFiles(); // get the files selected by the users
            foreach (var imageFile in imageFiles)
            {
                if (imageFile != null)
                {
                    var resizedFile = await imageFile.RequestImageFileAsync(imageFile.ContentType, 300, 500);
                    using var stream = resizedFile.OpenReadStream(resizedFile.Size);
                    var content = new MultipartFormDataContent();
                    content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                    content.Add(new StreamContent(stream, Convert.ToInt32(resizedFile.Size)), "image", imageFile.Name);

                    if (RoomHttpRepository is not null)
                    {
                        ImgUrl = await RoomHttpRepository.UploadImages(content);
                        await OnChange.InvokeAsync(ImgUrl);
                    }
                }
            }
        }
    }
}