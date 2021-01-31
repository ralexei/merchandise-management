using MediatR;
using MerchandiseManager.Application.Contexts.SalesReports.ViewModels;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Application.Models.Filtering;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.SalesReports.Queries.GetSalesReports
{
	public class GetSalesReportsQueryHandler : IRequestHandler<GetSalesReportsQuery, FilteredResult<SalesReportViewModel>>
	{
		private readonly IDbContext context;

		public GetSalesReportsQueryHandler(IDbContext context)
		{
			this.context = context;
		}

		public async Task<FilteredResult<SalesReportViewModel>> Handle(GetSalesReportsQuery request, CancellationToken cancellationToken)
		{
			var soldProducts = context
				.SoldProducts
				.Where(w => w.StoreId == request.StoreId);

			if (request.FromDate.HasValue)
				soldProducts = soldProducts.Where(w => w.CreatedAt > request.FromDate.Value);

			if (request.ToDate.HasValue)
				soldProducts = soldProducts.Where(w => w.CreatedAt < request.ToDate.Value);

			soldProducts = soldProducts.Select(s => new SalesReportViewModel)

			return new FilteredResult(soldProducts.Select(s => ))
		}
	}
}
