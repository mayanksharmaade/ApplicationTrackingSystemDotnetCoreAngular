using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Business.Interfaces
{
    public interface IFileStorageService
    {
       
       
            Task<string> UploadAsync(IFormFile file, string folder);
            Task DeleteAsync(string fileUrl);
        }
    }

