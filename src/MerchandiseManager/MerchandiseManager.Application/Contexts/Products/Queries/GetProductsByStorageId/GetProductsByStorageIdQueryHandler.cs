﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MerchandiseManager.Application.Contexts.Products.ViewModels;
using MerchandiseManager.Application.Helpers.Extensions.Linq;
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
		: IRequestHandler<GetProductsByStorageIdQuery, FilteredResult<StorageProductViewModel>>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;

		public GetProductsByStorageIdQueryHandler(IDbContext db, IMapper mapper)
		{
			this.db = db;
			this.mapper = mapper;
		}

		public async Task<FilteredResult<StorageProductViewModel>> Handle
			(GetProductsByStorageIdQuery request, CancellationToken cancellationToken)
		{
			var storageProducts = db.StorageProducts
						.Include(i => i.Product)
						.Where(w => w.StorageId == request.StorageId);


			if (!string.IsNullOrEmpty(request.ProductNameContains))
				storageProducts = storageProducts.Where(w => w.Product.ProductName.Contains(request.ProductNameContains));

			var query = storageProducts
				.ProjectTo<StorageProductViewModel>(mapper.ConfigurationProvider);

			if (request.CategoryId != null)
			{
				var subCategories = db.Categories
					.Include(i => i.Children)
					.AsEnumerable()
					.Where(w => w.Id == request.CategoryId)
					.ToList()
					.Flatten(f => f.Children)
					.Select(s => s.Id);
				query = query.Where(w => subCategories.Contains(w.Product.CategoryId));
			}

			if (request.BuyPriceMax.HasValue)
				query = query.Where(w => w.Product.BuyPrice < request.BuyPriceMax.Value);
			if (request.BuyPriceMin.HasValue)
				query = query.Where(w => w.Product.BuyPrice > request.BuyPriceMin.Value);
			if (request.RetailSellPriceMax.HasValue)
				query = query.Where(w => w.Product.RetailSellPrice < request.RetailSellPriceMax.Value);
			if (request.RetailSellPriceMin.HasValue)
				query = query.Where(w => w.Product.RetailSellPrice < request.RetailSellPriceMin.Value);
			if (request.WholesaleSellPriceMax.HasValue)
				query = query.Where(w => w.Product.WholesaleSellPrice < request.WholesaleSellPriceMax.Value);
			if (request.WholesaleSellPriceMin.HasValue)
				query = query.Where(w => w.Product.WholesaleSellPrice < request.WholesaleSellPriceMin.Value);

			var filteredCount = await query.CountAsync();
			var resultProducts = await query
				.Paginate(request)
				.ToListAsync();

			return new FilteredResult<StorageProductViewModel>(resultProducts, filteredCount, resultProducts.Count);
		}
	}
}
