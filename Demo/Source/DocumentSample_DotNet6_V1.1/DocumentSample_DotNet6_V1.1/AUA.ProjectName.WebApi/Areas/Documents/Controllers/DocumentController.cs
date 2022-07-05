using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.EntitiesDto.Documents;
using AUA.ProjectName.Models.ViewModels.Documents.DoumentViewModels;
using AUA.ProjectName.Services.EntitiesService.Documents.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.Documents.Contracts;
using AUA.ProjectName.WebApi.Controllers;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace AUA.ProjectName.WebApi.Areas.FileFample.Controllers
{
    public class DocumentController : BaseApiController
    {
        private readonly IUploadValidationService _uploadValidationService;
        private readonly IDocumentService _documentService;

        public DocumentController(IUploadValidationService uploadValidationService, IDocumentService documentService)
        {
            _uploadValidationService = uploadValidationService;
            _documentService = documentService;
        }

        [AllowAnonymousAuthorize]
        [HttpPost]
        public async Task<ResultModel<UploadResultVm>> UploadAysnc([FromForm] UploadVm uploadVm)
        {
            await ValidationAsync(uploadVm);

            if (HasError)
                return CreateInvalidResult<UploadResultVm>();

            var result = await UploadFileAsync();

            return CreateSuccessResult(result);
        }

        private async Task ValidationAsync(UploadVm uploadVm)
        {
            ValidationResultVm = await _uploadValidationService
                                                 .ValidationAsync(uploadVm);
        }

        private async Task<UploadResultVm> UploadFileAsync()
        {
            var validationResultModel = _uploadValidationService.GetResultModel();

            return await _documentService.UploadAsync(validationResultModel);
        }

        [AllowAnonymousAuthorize]
        [HttpGet]
        public async Task<ResultModel<List<DocumentDto>>> GetDocumentsAysnc()
        {
            var resultDto = await _documentService.GetAllDto()
                                                  .ToListAsync();

            return CreateSuccessResult(resultDto);
        }

        [AllowAnonymousAuthorize]
        [HttpGet]
        public async Task<FileContentResult> DownloadDocumentAysnc(Guid fileKey)
        {
            var resultDto = await _documentService.GetAllDto().FirstOrDefaultAsync(p => p.FileKey == fileKey);

            if (resultDto is null)
                return CreateNotFindFileMessage();


            var file = Getfile(resultDto.FilePath, resultDto.DocumentType.ContentType);

            await _documentService.AddDownloadCount(resultDto.Id);

            return file;
        }

        private static FileContentResult Getfile(string path, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(path);

            return new FileContentResult(fileBytes, contentType);

        }

        private static FileContentResult CreateNotFindFileMessage()
        {
            var contentType = "text/xml";
            var content = "<content>File not find </content>";
            var bytes = Encoding.UTF8.GetBytes(content);
            var result = new FileContentResult(bytes, contentType);
            return result;

        }
    }
}
