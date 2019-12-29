using MerchandiseManager.Core.Entities;
using MerchandiseManager.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class DiscountPackageConfiguration : BaseEntityConfiguration<DiscountPackage>
	{
		public override void Configure(EntityTypeBuilder<DiscountPackage> builder)
		{
			base.Configure(builder);

			builder
				.Property(p => p.MaxAmount)
				.IsRequired(false)
				.HasColumnType("decimal(18, 2)");
			builder
				.Property(p => p.MinAmount)
				.IsRequired(false)
				.HasColumnType("decimal(18, 2)");
			builder
				.Property(p => p.Percent)
				.IsRequired(false)
				.HasColumnType("decimal(18, 2)");
			builder
				.Property(p => p.DiscountSum)
				.IsRequired(false)
				.HasColumnType("decimal(18, 2)");
			builder
				.Property(p => p.DiscountType)
				.HasConversion(new EnumToStringConverter<DiscountTypes>());
		}
	}
}
