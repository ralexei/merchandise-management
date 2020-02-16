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

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetProductsByStorageId
{
	public class GetProductsByStorageIdQueryHandler
		: IRequestHandler<GetProductsByStorageIdQuery, FilteredResult<ProductViewModel>>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;

		public GetProductsByStorageIdQueryHandler(IDbContext db, IMapper mapper)
		{
			this.db = db;
			this.mapper = mapper;
		}

		public async Task<FilteredResult<ProductViewModel>> Handle
			(GetProductsByStorageIdQuery request, CancellationToken cancellationToken)
		{
			var products = db.StorageProducts
						.Where(w => w.StorageId == request.StorageId)
						.Select(s => s.Product);
			var productsTotal = await products.CountAsync();
			var filteredProducts = await products
								.ProjectTo<ProductViewModel>(mapper.ConfigurationProvider)
								.Paginate(request)
								.ToListAsync();

			return new FilteredResult<ProductViewModel>(filteredProducts, productsTotal, filteredProducts.Count);
		}
	}
}
