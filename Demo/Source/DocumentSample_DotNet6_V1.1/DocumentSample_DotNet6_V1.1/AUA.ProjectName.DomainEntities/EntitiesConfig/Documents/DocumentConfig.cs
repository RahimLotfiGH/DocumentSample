using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Documents
{
    public class DocumentConfig : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {

            builder
                .Property(p => p.DocumentName)
                .HasMaxLength(LengthConsts.MaxStringLen100);         

            builder
                .Property(p => p.FileKey)
                .IsRequired();

            builder
              .HasOne(p => p.DocumentType)
              .WithMany(p => p.Documents)
              .HasForeignKey(p => p.DocumentTypeId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(p => !p.IsDeleted);

        }

    }
}
