using MediatR;
using MerchandiseManager.Application.Contexts.Categories.ViewModels;
using MerchandiseManager.Application.Models.Filtering;

namespace MerchandiseManager.Application.Contexts.Categories.Queries.GetAllCategories
{
	public class GetAllCategoriesQuery : IRequest<FilteredResult<CategoryViewModel>>
	{
	}
}
