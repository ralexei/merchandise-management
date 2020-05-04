using MediatR;
using MerchandiseManager.Application.Contexts.SoldProducts.ViewModels;
using MerchandiseManager.Application.Interfaces.Models.Filtering;
using MerchandiseManager.Application.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.SoldProducts.Queries.GetAllProductsFiltered
{
	public class GetAllProductsFilteredQuery : IPaginatable, IRequest<FilteredResult<SoldProductViewModel>>
	{
		public int? Page { get; set; }

		public int? PageSize { get; set; }
	}
}
