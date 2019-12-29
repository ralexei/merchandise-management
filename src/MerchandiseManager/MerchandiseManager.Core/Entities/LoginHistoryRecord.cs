using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;

namespace MerchandiseManager.Core.Entities
{
	public partial class LoginHistoryRecord : BaseEntity 
	{
		public User User { get; private set; }
		public Guid UserId { get; private set; }
	}
}
