using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Products.Commands.AddNewProduct
{
	public class AddNewProductCommand : IRequest<Unit>
	{
		public string ProductName { get; private set; }
		public string ProductDescription { get; private set; }

		public decimal RetailSellPrice { get; private set; }
		public decimal? WholesaleSellPrice { get; private set; }
		public decimal? BuyPrice { get; private set; }

		public Guid? CategoryId { get; private set; }
	}
}
