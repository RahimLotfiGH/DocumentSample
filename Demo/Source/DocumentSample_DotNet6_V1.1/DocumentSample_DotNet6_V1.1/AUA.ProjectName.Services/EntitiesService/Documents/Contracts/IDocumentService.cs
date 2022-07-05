using AUA.ProjectName.DomainEntities.Entities.Documents;
using AUA.ProjectName.Models.DataModels.Documents;
using AUA.ProjectName.Models.EntitiesDto.Documents;
using AUA.ProjectName.Models.ViewModels.Documents.DoumentViewModels;
using AUA.ServiceInfrastructure.BaseServices;

namespace AUA.ProjectName.Services.EntitiesService.Documents.Contracts
{
    public interface IDocumentService : IGenericEntityService<Document, DocumentDto,long>
    {
        Task<UploadResultVm> UploadAsync(UploadValidationResult uploadValidationResult);

        Task AddDownloadCount(long id);
    }
}
