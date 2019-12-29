﻿using MerchandiseManager.Core.Constants.Validation;
using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class ProductConfiguration : BaseEntityConfiguration<Product>
	{
		public override void Configure(EntityTypeBuilder<Product> builder)
		{
			base.Configure(builder);

			builder
				.Property(p => p.BuyPrice)
				.HasColumnType("decimal(18,2)");
			builder
				.Property(p => p.ProductDescription)
				.HasMaxLength(ProductConstants.MaxProductDescriptionLength);
			builder
				.Property(p => p.ProductName)
				.HasMaxLength(ProductConstants.MaxProductNameLength);
			builder
				.Property(p => p.RetailSellPrice)
				.HasColumnType("decimal(18,2)");
			builder.Property(p => p.WholesaleSellPrice)
				.HasColumnType("decimal(18,2)");
		}
	}
}