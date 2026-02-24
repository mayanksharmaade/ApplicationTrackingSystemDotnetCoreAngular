using ApplicationTrackingSystem.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Business.Repositories
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IConfiguration _config;
        //private readonly IWebHostEnvironment _env;

        public FileStorageService(IConfiguration config)
        {
            _config = config;
          //  _env = env;
        }

        public async Task<string> UploadAsync(IFormFile file, string folder)
        {
            var ext = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{ext}";
            var uploadPath = Path.Combine("", "uploads", folder);
            Directory.CreateDirectory(uploadPath);
            var fullPath = Path.Combine(uploadPath, fileName);
            using var stream = File.Create(fullPath);
            await file.CopyToAsync(stream);
            var baseUrl = _config["FileStorage:BaseUrl"];
            return $"{baseUrl}/{folder}/{fileName}";
        }

        public Task DeleteAsync(string fileUrl)
        {
            // Parse path from URL and delete file
            return Task.CompletedTask;
        }
    }

}

