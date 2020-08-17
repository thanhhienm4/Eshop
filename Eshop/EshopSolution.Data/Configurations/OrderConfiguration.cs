using  EshopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace  EshopSolution.Data.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ShipAddress).IsRequired().IsUnicode(true);
            builder.Property(x => x.ShipName).IsRequired().IsUnicode(true);
            builder.Property(x => x.ShipAddress).IsRequired().IsUnicode(true);

        }
    }
}
