using MerchandiseManager.Core.Interfaces.Entity;
using System;

namespace MerchandiseManager.Core.Entities
{
	public partial class DiscountPackage : IBaseEntity, IHasId<Guid>, IHasDate
	{
		public Guid Id { get; private set; }

		public DateTime CreationTime { get; private set; }
		public DateTime? UpdateTime { get; private set; }
	}
}
