using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Documents;
using AUA.ProjectName.Models.EntitiesDto.Documents;
using AUA.ProjectName.Services.EntitiesService.Documents.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;

namespace AUA.ProjectName.Services.EntitiesService.Documents.Services
{
    public class DocumentTypeService : GenericEntityService<DocumentType, DocumentTypeDto>, IDocumentTypeService
    {
        public DocumentTypeService(IUnitOfWork unitOfWork, IMapper mapperInstance) : base(unitOfWork, mapperInstance)
        {

        }


    }
}
