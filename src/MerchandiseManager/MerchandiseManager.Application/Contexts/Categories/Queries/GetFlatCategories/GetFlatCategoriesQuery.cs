using MediatR;
using MerchandiseManager.Application.Contexts.Categories.ViewModels;
using MerchandiseManager.Application.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Categories.Queries.GetFlatCategories
{
	public class GetFlatCategoriesQuery : IRequest<FilteredResult<CategoryFlatViewModel>>
	{
		
	}
}
