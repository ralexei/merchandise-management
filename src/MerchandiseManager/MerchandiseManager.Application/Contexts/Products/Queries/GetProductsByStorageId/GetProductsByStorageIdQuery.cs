using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Interfaces.Models.Filtering;
using MerchandiseManager.Application.Models.Filtering;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetProductsByStorageId
{
	public class GetProductsByStorageIdQuery : IPaginatable, IRequest<FilteredResult<ProductViewModel>>
	{
		[FromRoute]
		public Guid? StorageId { get; set; }

		public int? Start { get; set; }

		public int? Limit { get; set; }
	}
}
