using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Interfaces.Models.Filtering;
using MerchandiseManager.Application.Models.Filtering;

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetAllProducts
{
	public class GetAllProductsQuery : IPaginatable, IRequest<FilteredResult<ProductViewModel>>
	{
		public int? Start { get; set; }

		public int? Limit { get; set; }
	}
}
