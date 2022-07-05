using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.DataModels.Documents;
using AUA.ProjectName.Models.ViewModels.Documents.DoumentViewModels;

namespace AUA.ProjectName.ValidationServices.Accounting.Documents.Contracts
{
    public interface IUploadValidationService
    {
        Task<ValidationResultVm> ValidationAsync(UploadVm uploadVm);

        UploadValidationResult GetResultModel();

    }
}
