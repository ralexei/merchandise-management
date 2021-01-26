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

		protected UserStorage(){}

		public UserStorage(Guid userId, Guid storageId)
		{
			UserId = userId;
			StorageId = storageId;
		}

		public UserStorage(Guid userId, Storage storage)
		{
			UserId = userId;
			Storage = storage;
		}
	}
}
