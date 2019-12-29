using MerchandiseManager.Core.Interfaces.Entity;
using System;

namespace MerchandiseManager.Core.Entities
{
	public partial class DeliveryNote : BaseEntity
	{
		public Storage SourceStorage { get; private set; }
		public Guid? SourceStorageId { get; private set; }

		public Storage DestinationStorage { get; private set; }
		public Guid DestinationStorageId { get; private set; }
	}
}
