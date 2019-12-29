using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Interfaces.Persistance;
using MerchandiseManager.Application.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetAllProducts
{
	public class GetAllProductsQueryHandler
		: IRequestHandler<GetAllProductsQuery, FilteredResult<ProductViewModel>>
	{
		private readonly IDbContext db;

		public GetAllProductsQueryHandler(IDbContext db)
		{
			this.db = db;
		}

		public async Task<FilteredResult<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			// @TODO to complete this use case:
			// Implement generic pagination functionallity
			// Add sorting functionallity (optional??) (Generic extension + interface for model)
			// Call this functionallity here
			throw new NotImplementedException();
			//return 
		}
	}
}
