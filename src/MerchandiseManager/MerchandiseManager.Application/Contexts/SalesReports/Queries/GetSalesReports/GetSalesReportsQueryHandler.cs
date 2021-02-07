using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.SalesReports.ViewModels;
using MerchandiseManager.Application.Contexts.SoldProducts.ViewModels;
using MerchandiseManager.Application.Helpers.Extensions.Queryable;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Application.Models.Filtering;
using MerchandiseManager.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.SalesReports.Queries.GetSalesReports
{
	public class GetSalesReportsQueryHandler : IRequestHandler<GetSalesReportsQuery, FilteredResult<SalesReportViewModel>>
	{
		private readonly IDbContext context;
		private readonly IMapper mapper;
		private readonly ICurrentUser currentUser;

		public GetSalesReportsQueryHandler(
			IDbContext context,
			IMapper mapper,
			ICurrentUser currentUser)
		{
			this.context = context;
			this.mapper = mapper;
			this.currentUser = currentUser;
		}

		public async Task<FilteredResult<SalesReportViewModel>> Handle(GetSalesReportsQuery request, CancellationToken cancellationToken)
		{
			var query = context
				.SalesReports
				.Include(i => i.SoldProducts)
					.ThenInclude(ti => ti.Product)
				.Where(w => w.StoreId == request.StoreId);

			if (request.FromDate.HasValue)
				query = query.Where(w => w.Day > DateTimeExtensions.ToDate(request.FromDate.Value));

			if (request.ToDate.HasValue)
				query = query.Where(w => w.Day < DateTimeExtensions.ToDate(request.ToDate.Value));

			var count = await query.CountAsync();

			var salesReports = query
				.Paginate(request)
				.Select(s => new SalesReportViewModel
				{
					SoldProducts = mapper.Map<List<SoldProductViewModel>>(s.SoldProducts.ToList()),
					Day = s.Day,
					TotalSum = s.SoldProducts.Sum(s => s.SoldAmount * s.SellPrice),
					UserSoldAmount = s.SoldProducts.Where(w => w.Product.UserId == currentUser.Id).Sum(s => s.SoldAmount * s.SellPrice)
				});

			return new FilteredResult<SalesReportViewModel>(salesReports, count, salesReports.Count());
		}
	}
}
