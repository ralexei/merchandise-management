using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class StorageProductConfiguration : BaseEntityConfiguration<StorageProduct>
	{
		public override void Configure(EntityTypeBuilder<StorageProduct> builder)
		{
			base.Configure(builder);

			builder
				.HasOne(ho => ho.Storage)
				.WithMany(wm => wm.StorageProducts);

			builder
				.HasOne(ho => ho.Product)
				.WithMany(wm => wm.StorageProducts);
		}
	}
}
