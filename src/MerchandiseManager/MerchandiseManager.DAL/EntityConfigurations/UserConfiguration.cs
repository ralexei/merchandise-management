using MerchandiseManager.Core.Constants.Validation;
using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class UserConfiguration : BaseEntityConfiguration<User>
	{
		public override void Configure(EntityTypeBuilder<User> builder)
		{
			base.Configure(builder);

			builder.Property(p => p.FirstName)
				.HasMaxLength(50);
			builder.Property(p => p.LastName)
				.IsRequired()
				.HasMaxLength(50);
			builder.Property(p => p.Username)
				.IsRequired()
				.HasMaxLength(UserConstants.MaxUsernameLength);

			builder.HasMany(hm => hm.LoginHistory).WithOne(wo => wo.User);
		}
	}
}
