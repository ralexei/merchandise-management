using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.SoldProducts.Commands.SellProductsFromCart
{
	public class SellProductsFromCartCommand : IRequest<Unit>
	{
		public Dictionary<Guid, int> SoldProducts { get; set; }
		public bool IsWholesale { get; set; }
		public decimal ReceivedSum { get; set; }
		public decimal Change { get; set; }
	}
}
