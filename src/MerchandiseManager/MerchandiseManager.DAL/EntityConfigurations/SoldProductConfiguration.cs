using MerchandiseManager.Core.Constants;
using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	class SoldProductConfiguration : BaseEntityConfiguration<SoldProduct>
	{
		public override void Configure(EntityTypeBuilder<SoldProduct> builder)
		{
			base.Configure(builder);

			builder
				.Property(p => p.BuyPrice)
				.HasColumnType(CommonPersistenceConstants.CommonDecimalConfig);

			builder
				.Property(p => p.SellPrice)
				.HasColumnType(CommonPersistenceConstants.CommonDecimalConfig);

			builder
				.Property(p => p.BuyPriceCurrency)
				.HasMaxLength(12);

			builder
				.HasOne(ho => ho.Seller)
				.WithMany(wm => wm.SoldProducts)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(ho => ho.Product)
				.WithMany()
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
