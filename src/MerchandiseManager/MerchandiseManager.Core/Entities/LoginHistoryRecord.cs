using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;

namespace MerchandiseManager.Core.Entities
{
	public partial class LoginHistoryRecord : IBaseEntity, IHasDate, IHasId<Guid>
	{
		public Guid Id { get; private set; }

		public DateTime CreationTime { get; private set; } 
		public DateTime? UpdateTime { get; private set; }

		public User User { get; private set; }
		public Guid UserGuid { get; private set; }
	}
}
