using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Interfaces.Authentication
{
	public interface ICurrentUser
	{
		public Guid Id { get; }
		public Guid StoreId { get; }
	}
}
