using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;

namespace MerchandiseManager.Core.Entities
{
	public class User : IBaseEntity, IHasDate, IHasId<Guid>
	{
		public Guid Id { get; private set; }
		public DateTime CreationTime { get; private set; }
		public DateTime? UpdateTime { get; private set; }
		public DateTime HireDate { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }

		public ICollection<LoginHistoryRecord> LoginHistory { get; private set; }
		//public ??? UserType { get; set; }
	}
}
