using MerchandiseManager.Register.DAL.Entities;
using System;

namespace MerchandiseManager.Register.WPF.Persistence.Entities
{
	public class BarCode : BaseEntity
	{
		public string RawCode { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
