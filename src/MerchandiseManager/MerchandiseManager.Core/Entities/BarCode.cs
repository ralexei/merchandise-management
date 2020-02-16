using MerchandiseManager.Core.Interfaces.Entity;
using System;

namespace MerchandiseManager.Core.Entities
{
	public class BarCode : BaseEntity
	{
		public string RawCode { get; private set; }
		
		public Guid ProductId { get; private set; }
		public Product Product { get; private set; }

		public BarCode(Guid productId, string rawCode) : this(rawCode)
		{
			ProductId = productId;
		}

		public BarCode(string rawCode)
		{
			if (string.IsNullOrEmpty(rawCode))
				throw new ArgumentNullException(nameof(rawCode));

			RawCode = rawCode;
		}
	}
}
