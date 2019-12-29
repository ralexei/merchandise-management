﻿using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class CategoryConfiguration : RecursiveEntityConfiguration<Category>
	{
		public override void Configure(EntityTypeBuilder<Category> builder)
		{
			base.Configure(builder);

			builder.Property(p => p.CategoryName)
				.HasMaxLength(64)
				.IsRequired();

			builder.Property(p => p.CategoryDescription)
				.HasMaxLength(128)
				.IsRequired();
		}
	}
}