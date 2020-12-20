using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Blog.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly string _imagePath;

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"];
        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var save_path = Path.Combine(_imagePath);
                if (!Directory.Exists(save_path)) Directory.CreateDirectory(save_path);

                //Internet Explorer error C:/user/foo/image.jpg
                //var fileName = image.FileName;
                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                var filename = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";
                using (var fileStream = new FileStream(Path.Combine(save_path, filename), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                return filename;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "error";
            }
        }
    }
}