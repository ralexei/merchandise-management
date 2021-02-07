using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.SoldProducts.Commands.SellProductsFromCart
{
	public class SellProductsFromCartCommandHandler : IRequestHandler<SellProductsFromCartCommand, Unit>
	{
		private readonly IDbContext db;
		private readonly ICurrentUser currentUser;
		private readonly IMapper mapper;

		public SellProductsFromCartCommandHandler(
			IDbContext db,
			ICurrentUser currentUser,
			IMapper mapper)
		{
			this.db = db;
			this.currentUser = currentUser;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(SellProductsFromCartCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var shop = await db.Storages
					.AsNoTracking()
					.FirstOrDefaultAsync(f => f.Id == currentUser.StoreId);
				var storageProducts = await db.StorageProducts
					.Include(i => i.Product)
					.Where(w => request.SoldProducts.Keys.Any(a => a == w.ProductId) && w.StorageId == shop.Id)
					.ToListAsync();
				var salesReport = await GetSalesReport(currentUser.StoreId);

				foreach (var storageProduct in storageProducts)
					storageProduct.DecreaseQuantityOfGoods(request.SoldProducts[storageProduct.ProductId]);
				
				var soldProducts = storageProducts
					.Select(s => SoldProduct
						.SellProduct(s.Product, currentUser.Id, request.SoldProducts[s.ProductId], request.IsWholesale)
						.AddToSalesReport(salesReport));

				await db.SoldCarts.AddAsync(SoldCart.SellCartWithProducts(request.ReceivedSum, request.Change, soldProducts));
				await db.SaveChangesAsync(cancellationToken);

				return Unit.Value;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private async Task<SalesReport> GetSalesReport(Guid storeId)
		{
			var salesReport = await db
				.SalesReports
				.AsNoTracking()
				.FirstOrDefaultAsync();

			if (salesReport == null)
				salesReport = new SalesReport(storeId);

			return salesReport;
		}
	}
}
