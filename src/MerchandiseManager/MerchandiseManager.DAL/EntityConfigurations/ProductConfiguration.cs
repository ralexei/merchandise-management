using MerchandiseManager.Core.Constants;
using MerchandiseManager.Core.Constants.Validation;
using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class ProductConfiguration : BaseEntityConfiguration<Product>
	{
		public override void Configure(EntityTypeBuilder<Product> builder)
		{
			base.Configure(builder);

			builder
				.Property(p => p.BuyPrice)
				.HasColumnType(CommonPersistenceConstants.CommonDecimalConfig);
			builder
				.Property(p => p.ProductDescription)
				.HasMaxLength(ProductConstants.MaxProductDescriptionLength);
			builder
				.Property(p => p.ProductName)
				.HasMaxLength(ProductConstants.MaxProductNameLength);
			builder
				.Property(p => p.RetailSellPrice)
				.HasColumnType(CommonPersistenceConstants.CommonDecimalConfig);

			builder.Property(p => p.WholesaleSellPrice)
				.HasColumnType(CommonPersistenceConstants.CommonDecimalConfig);

			builder.Property(p => p.BarcodeFriendlyId)
				.ValueGeneratedOnAdd();

			//builder.Property(p => p.BarCodeRaw)
			//	.HasMaxLength(ProductConstants.MaxBarCodeRawLength);
		}
	}
}
