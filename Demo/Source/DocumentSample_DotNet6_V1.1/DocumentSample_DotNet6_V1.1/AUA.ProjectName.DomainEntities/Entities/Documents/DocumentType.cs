using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Documents
{
    [Table("DocumentType", Schema = SchemaConsts.Document)]
    public sealed class DocumentType : DomainEntity<int>
    {
        public string TypeName { get; set; }

        public string FileExtension { get; set; }

        public int MaximomSizeKB { get; set; }

        public string ContentType { get; set; }

        public string IconName { get; set; }

        public bool IsUploadClosed { get; set; }

        public ICollection<Document> Documents { get; set; }

    }
}
