using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class DeliveryNoteProduct : BaseEntity 
	{
		public int Amount { get; private set; }

		public Product Product { get; private set; }
		public Guid ProductId { get; private set; }

		public DeliveryNote DeliveryNote { get; private set; }
		public Guid DeliveryNoteId { get; private set; }
	}
}
