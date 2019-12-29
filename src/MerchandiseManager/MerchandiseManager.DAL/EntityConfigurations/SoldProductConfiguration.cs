using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	class SoldProductConfiguration : BaseEntityConfiguration<SoldProduct>
	{
		public override void Configure(EntityTypeBuilder<SoldProduct> builder)
		{
			base.Configure(builder);

			builder
				.Property(p => p.BuyPrice)
				.HasColumnType("decimal(18,2)");

			builder
				.Property(p => p.SellPrice)
				.HasColumnType("decimal(18,2)");

			builder
				.Property(p => p.BuyPriceCurrency)
				.HasMaxLength(12);

			builder
				.HasOne(ho => ho.Seller)
				.WithMany(wm => wm.SoldProducts);
		}
	}
}
