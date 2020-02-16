using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MerchandiseManager.Application.Contexts.SoldProducts.ViewModels;
using MerchandiseManager.Application.Helpers.Extensions.Queryable;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Application.Models.Filtering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.SoldProducts.Queries.GetAllProductsFiltered
{
	public class GetAllProductsFilteredQueryHandler
		: IRequestHandler<GetAllProductsFilteredQuery, FilteredResult<SoldProductViewModel>>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;

		public GetAllProductsFilteredQueryHandler(IDbContext db, IMapper mapper)
		{
			this.db = db;
			this.mapper = mapper;
		}

		public async Task<FilteredResult<SoldProductViewModel>> Handle
			(GetAllProductsFilteredQuery request, CancellationToken cancellationToken)
		{
			// @TODO to complete this use case:
			// Add filtering + sorting
			var totalCount = await db.SoldProducts.CountAsync();
			var resultData = await db.SoldProducts
				.AsNoTracking()
				.ProjectTo<SoldProductViewModel>(mapper.ConfigurationProvider)
				.Paginate(request)
				.ToListAsync();

			return new FilteredResult<SoldProductViewModel>(resultData, totalCount, resultData.Count());
		}
	}
}
