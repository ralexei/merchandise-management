using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class DeliveryNoteConfiguration : BaseEntityConfiguration<DeliveryNote>
	{
		public override void Configure(EntityTypeBuilder<DeliveryNote> builder)
		{
			base.Configure(builder);

			builder
				.HasOne(ho => ho.DestinationStorage)
				.WithOne()
				.HasForeignKey<DeliveryNote>(fk => fk.DestinationStorageId);

			builder
				.HasOne(ho => ho.SourceStorage)
				.WithOne()
				.HasForeignKey<DeliveryNote>(fk => fk.SourceStorageId)
				.IsRequired(false);
		}
	}
}
