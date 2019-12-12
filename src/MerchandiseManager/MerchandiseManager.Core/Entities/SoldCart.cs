using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class SoldCart : IHasId<Guid>, IBaseEntity, IHasDate
	{
		public Guid Id { get; private set; }

		public DateTime CreationTime { get; private set; }
		public DateTime? UpdateTime { get; private set; }

		public decimal TotalPrice { get; private set; }
		public decimal PaidSum { get; private set; }
		public decimal Change { get; private set; }

		public ICollection<SoldProduct> SoldProcuts { get; private set; }
	}
}
