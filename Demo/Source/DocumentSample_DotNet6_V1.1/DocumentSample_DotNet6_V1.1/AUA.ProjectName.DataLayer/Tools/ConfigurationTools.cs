﻿using AUA.ProjectName.DomainEntities.BaseEntities;
using AUA.ProjectName.DomainEntities.EntitiesConfig.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AUA.ProjectName.DataLayer.Tools
{
    public static class ConfigurationTools
    {
        public static void LoadConfigurations(ModelBuilder builder)
        {

            builder
                .ApplyConfigurationsFromAssembly(typeof(DocumentConfig).Assembly);

            AddDefaultValueSql(builder);

        }

        private static void AddDefaultValueSql(ModelBuilder modelBuilder)
        {
            var entityTypes = GetEntityTypes(modelBuilder);

            foreach (var entityType in entityTypes)
            {
                modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        x.Property("RegistrationDate")
                            .HasColumnType("datetime2(3)")
                            .HasDefaultValueSql("GetDate()");

                    });
            }

        }

        private static IEnumerable<IMutableEntityType> GetEntityTypes(ModelBuilder modelBuilder)
        {
            return modelBuilder
                        .Model
                        .GetEntityTypes()
                        .Where(t => t.ClrType.IsSubclassOf(typeof(DomainEntity)) ||
                                    t.ClrType.IsSubclassOf(typeof(DomainEntity<string>)) ||
                                    t.ClrType.IsSubclassOf(typeof(DomainEntity<Guid>)) ||
                                    t.ClrType.IsSubclassOf(typeof(DomainEntity<long>))
                        );

        }

    }
}
