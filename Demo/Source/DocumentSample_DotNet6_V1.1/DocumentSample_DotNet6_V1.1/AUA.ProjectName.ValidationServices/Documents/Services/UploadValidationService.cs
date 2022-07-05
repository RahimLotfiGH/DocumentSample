using AUA.ProjectName.DomainEntities.Entities.Documents;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.DataModels.Documents;
using AUA.ProjectName.Models.ViewModels.Documents.DoumentViewModels;
using AUA.ProjectName.Services.EntitiesService.Documents.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.Documents.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Services
{
    public class UploadValidationService : BaseValidationService, IUploadValidationService
    {
        private UploadVm _uploadVm;
        private DocumentType _documentType;
        private readonly IDocumentTypeService _documentTypeService;
        public UploadValidationResult _uploadValidationResult;

        public UploadValidationService(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        public async Task<ValidationResultVm> ValidationAsync(UploadVm uploadVm)
        {
            _uploadVm = uploadVm;

            await DoValidationAsync();

            return ValidationResultVm;
        }

        private async Task DoValidationAsync()
        {

            DefaultValidation();

            if (HasError) return;

            await GetDocumentTypeAysnc();

            ValidationDocumentTypeAsync();

            if (HasError) return;

            ValidationFileAsync();

            SetResultValues();
        }

        private void SetResultValues()
        {
            _uploadValidationResult = new UploadValidationResult
            {
                File = _uploadVm.File,
                DocumentTypeId = _documentType.Id
            };
        }

        private void DefaultValidation()
        {
            if (_uploadVm.File is null)
                AddError("File", "File is Null");
        }

        private async Task GetDocumentTypeAysnc()
        {
            _documentType = await _documentTypeService.GetAll()
                                               .FirstOrDefaultAsync(p => p.FileExtension == FileExtension);

        }

        private void ValidationDocumentTypeAsync()
        {
            if (_documentType is null)
                AddError("documentType", "document type is not allow ");

            if (HasError) return;

            if (_documentType.IsUploadClosed)
                AddError("documentType", "document type was upload closed ");

            if (_documentType.ContentType.Trim().ToLower() != FileContentType)
                AddError("FileContent", "document type is not correct ");

        }

        private void ValidationFileAsync()
        {
            if (_documentType.MaximomSizeKB < FileSizeKB)
                AddError("File", "document type is nut allow ");

        }

        public UploadValidationResult GetResultModel()
        {
            return _uploadValidationResult;
        }

        private long FileSizeKB => _uploadVm.File.Length / 1204;

        private string FileExtension => Path.GetExtension(_uploadVm.File.FileName)
                                            .Replace('.', ' ')
                                            .Trim()
                                            .ToLower();

        private string FileContentType => _uploadVm.File
                                                   .ContentType
                                                   .Replace('.', ' ')
                                                   .Trim()
                                                   .ToLower();


    }
}
