using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Documents
{
    [Table("Document", Schema = SchemaConsts.Document)]
    public sealed class Document : DomainEntity<long>
    {
        public Guid FileKey { get; set; }

        public string DocumentName { get; set; }

        public int DownloadCount { get; set; }

        public DocumentType DocumentType { get; set; }

        public int DocumentTypeId { get; set; }

    }
}
