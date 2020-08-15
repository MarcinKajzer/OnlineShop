using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Shop.Helpers
{
    public class ImageUploader
    {
        private readonly IWebHostEnvironment _environment;

        public ImageUploader(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task Upload(IFormFile file, string newFileName)
        {
            if (file.Length > 0)
            {
                string wwwPath = _environment.WebRootPath;
                string filePath = Path.Combine(wwwPath, "products-images", newFileName + ".jpg");

                using (var stream = File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }
    }
}
