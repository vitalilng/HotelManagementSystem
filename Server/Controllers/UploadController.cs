using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelManagementSystem.Server.Controllers
{
    /// <summary>
    /// Upload images controller
    /// </summary>
    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        /// <summary>
        /// Upload method - extracts the files from Request
        /// and creates path for local storage and db
        /// after that file is copied to the stream
        /// </summary>
        /// <returns>path for database</returns>
        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName?.Trim('"') ?? string.Empty;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(dbPath);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }
        }
    }
}
