using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Interfaces.Models.Filtering;
using MerchandiseManager.Application.Models.Filtering;
using System;

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetAllProducts
{
	public class GetAllProductsQuery : IPaginatable, IRequest<FilteredResult<ProductViewModel>>
	{
		public int? Page { get; set; }

		public int? PageSize { get; set; }

		public Guid? CategoryId { get; set; }

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
