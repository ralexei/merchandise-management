using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Helpers.Extensions.Queryable;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Application.Models.Filtering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetAllProducts
{
	public class GetAllProductsQueryHandler
		: IRequestHandler<GetAllProductsQuery, FilteredResult<ProductViewModel>>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;

		public GetAllProductsQueryHandler(IDbContext db, IMapper mapper)
		{
			this.db = db;
			this.mapper = mapper;
		}

		public async Task<FilteredResult<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			// @TODO to complete this use case:
			// Add filtering + sorting
			var totalCount = await db.Products.CountAsync();
			var resultData = await db.Products
				.AsNoTracking()
				.Include(i => i.StorageProducts)
				.ProjectTo<ProductViewModel>(mapper.ConfigurationProvider)
				.Paginate(request)
				.ToListAsync();

			return new FilteredResult<ProductViewModel>(resultData, totalCount, resultData.Count());
		}
	}
}
