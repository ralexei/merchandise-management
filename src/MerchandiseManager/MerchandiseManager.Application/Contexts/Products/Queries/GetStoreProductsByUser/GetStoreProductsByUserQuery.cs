using MediatR;
using MerchandiseManager.Application.Contexts.StorageProducts.ViewModels;
using MerchandiseManager.Application.Interfaces.Models.Filtering;
using MerchandiseManager.Application.Models.Filtering;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetStoreProductsByUser
{
	public class GetStoreProductsByUserQuery : IPaginatable, IRequest<FilteredResult<StorageProductViewModel>>
	{
		[FromRoute]
		public Guid? StoreId { get; set; }

		public int? Page { get; set; }

		public int? PageSize { get; set; }

		public Guid? CategoryId { get; set; }

		public bool OnlyOutOfStock { get; set; }

		#region Contains filters
		public string ProductNameContains { get; set; }
		#endregion

		#region MinMaxFilters
		public decimal? RetailSellPriceMin { get; set; }
		public decimal? RetailSellPriceMax { get; set; }
		public decimal? WholesaleSellPriceMin { get; set; }
		public decimal? WholesaleSellPriceMax { get; set; }
		public decimal? BuyPriceMin { get; set; }
		public decimal? BuyPriceMax { get; set; }
		#endregion
	}
}
