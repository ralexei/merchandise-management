using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Helpers.Extensions.Linq;
using MerchandiseManager.Application.Helpers.Extensions.Queryable;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Application.Models.Filtering;
using Microsoft.EntityFrameworkCore;
using System;
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
			var query = db.Products
				.AsNoTracking()
				.Include(i => i.StorageProducts)
				.Include(i => i.BarCodes)
				.ProjectTo<ProductViewModel>(mapper.ConfigurationProvider)
				.AsQueryable();

			if (request.CategoryId != null)
			{
				var subCategories = db.Categories
					.Include(i => i.Children)
					.AsEnumerable()
					.Where(w => w.Id == request.CategoryId)
					.ToList()
					.Flatten(f => f.Children)
					.Select(s => s.Id);
				query = query.Where(w => subCategories.Contains(w.CategoryId));
			}

			query = query
				.OrderBy(o => o.ProductName)
				.FilterContaing(request)
				.FilterMinMax(request);

			var filteredCount = await query.CountAsync();
			var resultData = await query
				.Paginate(request)
				.ToListAsync();

			return new FilteredResult<ProductViewModel>(resultData, filteredCount, resultData.Count);
		}
	}
}
