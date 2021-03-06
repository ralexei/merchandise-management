﻿using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using System;
using System.Collections.Generic;

namespace MerchandiseManager.Application.Contexts.Products.Commands.EditProduct
{
	public class EditProductCommand : IRequest<ProductViewModel>
	{
		public Guid Id { get; set; }

		public string ProductName { get; set; }
		public string ProductDescription { get; set; }

		public decimal? RetailSellPrice { get; set; }
		public decimal? WholesaleSellPrice { get; set; }
		public decimal? BuyPrice { get; set; }

		public Guid? CategoryId { get; set; }

		public string[] Barcodes { get; set; }
	}
}
