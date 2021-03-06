﻿using EshopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EshopSolution.Data.Configurations
{
    public class AppConfigConfigurarion : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            builder.ToTable("AppConfigs");
            builder.HasKey(x => x.Key);
            builder.Property(x => x.Value).IsRequired(true);
        }
    }
}