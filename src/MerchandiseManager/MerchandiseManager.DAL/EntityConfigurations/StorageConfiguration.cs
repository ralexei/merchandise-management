using MerchandiseManager.Core.Entities;
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
				.Property(p => p.StorageName)
				.HasMaxLength(128);
			builder
				.Property(p => p.StorageDescription)
				.HasMaxLength(256);
		}
	}
}
