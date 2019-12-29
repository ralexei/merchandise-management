using MerchandiseManager.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Entities
{
	public partial class SoldCart : BaseEntity
	{
		public decimal TotalPrice { get; private set; }
		public decimal ReceivedSum { get; private set; }
		public decimal Change { get; private set; }

		public ICollection<SoldProduct> SoldProcuts { get; private set; }
	}
}
