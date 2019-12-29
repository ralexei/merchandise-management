using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	class SoldCartConfiguration : BaseEntityConfiguration<SoldCart>
	{
		public override void Configure(EntityTypeBuilder<SoldCart> builder)
		{
			base.Configure(builder);

			builder
				.Property(p => p.TotalPrice)
				.HasColumnType("decimal(18,2)");

			builder
				.Property(p => p.ReceivedSum)
				.HasColumnType("decimal(18,2)");

			builder
				.Property(p => p.Change)
				.HasColumnType("decimal(18,2)");

			builder
				.HasMany(hm => hm.SoldProcuts)
				.WithOne();
		}
	}
}
