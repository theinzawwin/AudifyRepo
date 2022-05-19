using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public interface IFirebaseService
    {
        Task<string> UploadFile(IFormFile file);
        Task<string> UploadAudio(IFormFile file);
        Task<string> UploadProfile(IFormFile file);
    }
}
