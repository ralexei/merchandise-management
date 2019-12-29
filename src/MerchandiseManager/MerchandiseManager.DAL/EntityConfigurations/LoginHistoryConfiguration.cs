using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.DAL.EntityConfigurations
{
	public class LoginHistoryConfiguration : BaseEntityConfiguration<LoginHistoryRecord>
	{
		public override void Configure(EntityTypeBuilder<LoginHistoryRecord> builder)
		{
			base.Configure(builder);
		}
	}
}
