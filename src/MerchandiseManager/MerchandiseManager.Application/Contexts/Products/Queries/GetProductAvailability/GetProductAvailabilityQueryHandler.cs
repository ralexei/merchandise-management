using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Contexts.Storages.ViewModels;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using MerchandiseManager.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetProductAvailability
{
	public class GetProductAvailabilityQueryHandler : IRequestHandler<GetProductAvailabilityQuery, IEnumerable<ProductAvailabilityViewModel>>
	{
		private readonly IDbContext context;
		private readonly IMapper mapper;

		public GetProductAvailabilityQueryHandler(IDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<ProductAvailabilityViewModel>> Handle(GetProductAvailabilityQuery request, CancellationToken cancellationToken)
		{
			var storageProducts = (await context
				.StorageProducts
				.AsNoTracking()
				.IgnoreQueryFilters()
				.Include(i => i.Product)
				.Include(i => i.Storage)
				.Where(w => w.Product.ProductName.Contains(request.ProductSearchTerm) && w.ProductsAmount > 0)
				.ToListAsync())
				.GroupBy(g => g.Product.ProductName);

			return storageProducts.Select(s => new ProductAvailabilityViewModel
			{
				ProductName = s.Key,
				Storages = s.Select(s => mapper.Map<StorageViewModel>(s.Storage))
			});
		}
	}
}
