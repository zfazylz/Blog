using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Blog.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);
        Task<string> SaveImage(IFormFile image);
    }
}