using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetProductAvailability
{
	public class GetProductAvailabilityQuery : IRequest<IEnumerable<ProductAvailabilityViewModel>>
	{
		public string ProductSearchTerm { get; set; }
	}
}
