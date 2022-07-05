using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Documents;
using AUA.ProjectName.Models.BaseModel.BaseDto;

namespace AUA.ProjectName.Models.EntitiesDto.Documents
{
    public sealed class DocumentTypeDto : BaseEntityDto<int>, IMapFrom<DocumentType>
    {
        public string TypeName { get; set; }

        public string FileExtension { get; set; }

        public int MaximomSizeKB { get; set; }

        public bool IsUploadClosed { get; set; }

        public string IconName { get; set; }

        public string ContentType { get; set; }

        public ICollection<Document> Documents { get; set; }

    }
}
