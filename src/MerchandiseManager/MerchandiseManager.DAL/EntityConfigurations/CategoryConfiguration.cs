using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class CategoryConfiguration : RecursiveEntityConfiguration<Category>
	{
		public override void Configure(EntityTypeBuilder<Category> builder)
		{
			base.Configure(builder);

			builder.Property(p => p.Name)
				.HasMaxLength(64)
				.IsRequired();

			builder.Property(p => p.Description)
				.HasMaxLength(128)
				.IsRequired();

			builder.Property(p => p.BarcodeFriendlyId)
				.ValueGeneratedOnAdd();
		}
	}
}
