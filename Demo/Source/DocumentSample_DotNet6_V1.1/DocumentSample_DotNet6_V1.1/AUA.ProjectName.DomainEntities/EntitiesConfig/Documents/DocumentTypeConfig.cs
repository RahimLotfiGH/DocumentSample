using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Documents
{
    public class DocumentTypeConfig : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {


            builder
                .Property(p => p.TypeName)
                .HasMaxLength(LengthConsts.MaxStringLen50);

            builder
               .Property(p => p.FileExtension)
               .HasMaxLength(LengthConsts.MaxStringLen50);

            builder
               .Property(p => p.IconName)
               .HasMaxLength(LengthConsts.MaxStringLen50);

            builder
               .Property(p => p.ContentType)
               .HasMaxLength(LengthConsts.MaxStringLen50);

            builder.HasQueryFilter(p => !p.IsDeleted);

        }

    }
}
