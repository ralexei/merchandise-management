using MerchandiseManager.Core.Interfaces.Entity;
using System;

namespace MerchandiseManager.Core.Entities
{
	public class UserStorage : BaseEntity
	{
		public Guid UserId { get; set; }
		public User User { get; set; }
		
		public Guid StorageId { get; set; }
		public Storage Storage { get; set; }

		public UserStorage(Guid userId)
		{
			UserId = userId;
		}
	}
}
