using MerchandiseManager.Core.Interfaces.Entity;
using System;

namespace MerchandiseManager.Core.Entities
{
	public class DeliveryNote : IBaseEntity, IHasDate, IHasId<Guid>
	{
		public Guid Id { get; private set; }

		public DateTime CreationTime { get; private set; }
		public DateTime? UpdateTime { get; private set; }

		public Storage SourceStorage { get; private set; }
		public Guid SourceStorageGuid { get; private set; }

		public Storage DestinationStorage { get; private set; }
		public Guid DestinationStorageGuid { get; private set; }
	}
}
