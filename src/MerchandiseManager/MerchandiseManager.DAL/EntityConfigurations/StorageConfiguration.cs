using MerchandiseManager.Core.Constants.Validation;
using MerchandiseManager.Core.Entities;
using MerchandiseManager.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class StorageConfiguration : BaseEntityConfiguration<Storage>
	{
		public override void Configure(EntityTypeBuilder<Storage> builder)
		{
			base.Configure(builder);

			builder
				.Property(p => p.Name)
				.HasMaxLength(StorageConstants.MaxStorageNameLength);

			builder
				.Property(p => p.Description)
				.HasMaxLength(StorageConstants.MaxStorageDescriptionLength);

			builder
				.HasDiscriminator<StorageTypes>(t => t.StorageType)
				.HasValue<Storage>(StorageTypes.None)
				.HasValue<Warehouse>(StorageTypes.Warehouse)
				.HasValue<Store>(StorageTypes.Store);

			builder
				.Property(p => p.StorageType)
				.HasConversion<string>();
		}
	}
}
