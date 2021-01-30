using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Register.WPF.Models.Request
{
	public class SubmitSoldCartRequest
	{
		public Dictionary<Guid, int> SoldProducts { get; set; }
		public bool IsWholesale { get; set; }
		public decimal ReceivedSum { get; set; }
		public decimal Change { get; set; }
	}
}
