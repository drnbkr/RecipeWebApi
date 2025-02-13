using Microsoft.AspNetCore.Http;

namespace Services.Contracts
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}