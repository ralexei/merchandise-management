using MerchandiseManager.Core.Constants;
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
				.HasColumnType(CommonPersistenceConstants.CommonDecimalConfig);

			builder
				.Property(p => p.ReceivedSum)
				.HasColumnType(CommonPersistenceConstants.CommonDecimalConfig);

			builder
				.Property(p => p.Change)
				.HasColumnType(CommonPersistenceConstants.CommonDecimalConfig);

			builder
				.HasMany(hm => hm.SoldProducts)
				.WithOne();
		}
	}
}
