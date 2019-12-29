using MerchandiseManager.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Interfaces.Entity
{
	public class BaseEntity
	{
		public Guid Id { get; set; }

		public long CreatedAt { get; private set; }
		public long? UpdatedAt { get; private set; }

		public void Updated()
		{
			UpdatedAt = DateTime.UtcNow.ToUnixTimestamp();
		}

		public void Created()
		{
			CreatedAt = DateTime.UtcNow.ToUnixTimestamp();
		}
	}
}
