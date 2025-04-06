﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.ProductId).IsRequired();
            builder.Property(i => i.ProductName).IsRequired();
            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.UnitPrice).IsRequired();
            builder.Property(i => i.Discount).IsRequired();
            builder.Property(i => i.IsCancelled).IsRequired();
        }
    }
}