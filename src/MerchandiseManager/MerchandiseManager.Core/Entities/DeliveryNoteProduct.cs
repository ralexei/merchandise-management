using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class DeliveryNoteProduct : IBaseEntity, IHasId<Guid>
	{
		public Guid Id { get; private set; }

		public int Amount { get; private set; }

		public Product Product { get; private set; }
		public Guid ProductGuid { get; private set; }

		public DeliveryNote DeliveryNote { get; private set; }
		public Guid DeliveryNoteGuid { get; private set; }
	}
}
