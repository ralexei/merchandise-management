using MerchandiseManager.Core.Interfaces.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public abstract class RecursiveEntityConfiguration<T> : BaseEntityConfiguration<T> where T : BaseEntity, IRecursiveEntity<T>
	{
		public new virtual void Configure(EntityTypeBuilder<T> builder)
		{
			base.Configure(builder);

			builder
				.HasMany(hm => hm.Children)
				.WithOne(wo => wo.Parent)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
