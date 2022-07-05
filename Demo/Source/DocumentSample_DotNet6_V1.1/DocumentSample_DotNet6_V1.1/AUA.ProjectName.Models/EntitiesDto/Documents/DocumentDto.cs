using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using AUA.ProjectName.DomainEntities.Entities.Documents;
using AUA.ProjectName.Models.BaseModel.BaseDto;
using AutoMapper;

namespace AUA.ProjectName.Models.EntitiesDto.Documents
{
    public sealed class DocumentDto : BaseEntityDto<long>, IHaveCustomMappings
    {
        public Guid FileKey { get; set; }

        public int DocumentTypeId { get; set; }

        public string DocumentName { get; set; }

        public int DownloadCount { get; set; }

        public DocumentType DocumentType { get; set; }

        public string DocumentFileName => FileKey.ToString() + "." + DocumentType.FileExtension;

        public string FilePath => Path.Combine(FileServerInfo.DefaultPassword, DocumentFileName);

        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<Document, DocumentDto>()
                .ForMember(p => p.DocumentType, p => p.MapFrom(q => q.DocumentType));

            configuration.CreateMap<DocumentDto, Document>();
        }
    }
}
