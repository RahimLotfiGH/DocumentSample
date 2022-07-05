using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using AUA.ProjectName.Services.GeneralService.UploadFile.Contents;
using Microsoft.AspNetCore.Http;

namespace AUA.ProjectName.Services.GeneralService.UploadFile.Services
{
    public class UploadFileService: IUploadFileService
    {
        //This class should upload file to file Manager microservice,
        //but in this sample save in folder(for this work is test)

        public async Task UploadFileAysnc(IFormFile fromFile, Guid guid)
        {
            var filePath = CrateFilePath(fromFile.FileName, guid);

            using var stream = File.Create(filePath);

            await fromFile.CopyToAsync(stream);
        }

        public static string CrateFilePath(string fileName, Guid guid)
        {
            return Path.Combine(FileServerInfo.DefaultPassword, 
                                guid.ToString() + Path.GetExtension(fileName));
        }
    }
}
