using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class WarehouseConfiguration : BaseEntityConfiguration<Warehouse>
	{
		public override void Configure(EntityTypeBuilder<Warehouse> builder)
		{
			base.Configure(builder);

			builder
				.HasOne(o => o.User)
				.WithMany(m => m.Warehouses)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
