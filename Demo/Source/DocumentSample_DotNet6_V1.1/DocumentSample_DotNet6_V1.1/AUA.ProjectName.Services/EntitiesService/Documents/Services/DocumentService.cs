using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Documents;
using AUA.ProjectName.Models.DataModels.Documents;
using AUA.ProjectName.Models.EntitiesDto.Documents;
using AUA.ProjectName.Models.ViewModels.Documents.DoumentViewModels;
using AUA.ProjectName.Services.EntitiesService.Documents.Contracts;
using AUA.ProjectName.Services.GeneralService.UploadFile.Contents;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AUA.ProjectName.Services.EntitiesService.Documents.Services
{
    public class DocumentService : GenericEntityService<Document, DocumentDto, long>, IDocumentService
    {
        private readonly IUploadFileService _uploadFileService;

        public DocumentService(IUnitOfWork unitOfWork, IMapper mapperInstance, IUploadFileService uploadFileService) : base(unitOfWork, mapperInstance)
        {
            _uploadFileService = uploadFileService;
        }

        public async Task<UploadResultVm> UploadAsync(UploadValidationResult uploadValidationResult)
        {
            var document = CreateDocument(uploadValidationResult);

            await InsertAsync(document);

            await UploadFileAysnc(uploadValidationResult.File, document.FileKey);

            return CreateResultModel(document.FileKey);
        }

        private static Document CreateDocument(UploadValidationResult uploadValidationResult)
        {
            return new Document
            {
                CreatorUserId = DbConsts.SystemUserId, // because user has not login token, 
                FileKey = Guid.NewGuid(),
                IsDeleted = false,
                DocumentTypeId = uploadValidationResult.DocumentTypeId,
                DocumentName = uploadValidationResult.File.FileName
            };
        }

        private async Task UploadFileAysnc(IFormFile file, Guid fileKey)
        {
            await _uploadFileService.UploadFileAysnc(file, fileKey);
        }


        private static UploadResultVm CreateResultModel(Guid fileKey)
        {
            return new UploadResultVm
            {
                FileKey = fileKey
            };
        }

        public async Task AddDownloadCount(long id)
        {
            var document = await GetByIdAsync(id);

            document.DownloadCount += 1;

            await UpdateAsync(document);
        }
    }
}
