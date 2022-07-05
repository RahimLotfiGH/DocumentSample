using Microsoft.AspNetCore.Http;
namespace AUA.ProjectName.Services.GeneralService.UploadFile.Contents
{
    public interface IUploadFileService
    {
        Task UploadFileAysnc(IFormFile fromFile, Guid guid);
    }
}
