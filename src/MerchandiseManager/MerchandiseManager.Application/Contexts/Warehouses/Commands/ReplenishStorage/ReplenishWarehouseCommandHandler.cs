using MediatR;
using MerchandiseManager.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Warehouses.Commands.ReplenishStorage
{
	public class ReplenishWarehouseCommandHandler : IRequestHandler<ReplenishWarehouseCommand>
	{
		private readonly IDbContext db;

		public ReplenishWarehouseCommandHandler(IDbContext db)
		{
			this.db = db;
		}

		public async Task Handle(ReplenishWarehouseCommand request, CancellationToken cancellationToken)
		{
			//if (request.SourceStorageId != null)
			//	ProcessSource(request.SourceStorageId.Value, request.Products);

			var destinationStorage = await db.Storages
									.Include(i => i.StorageProducts)
									.FirstOrDefaultAsync(f => f.Id == request.StorageId);

			destinationStorage.Replenish(request.Products);

			await db.SaveChangesAsync(cancellationToken);
		}

		private void ProcessSource(Guid storageId, Dictionary<Guid, int> products)
		{
			var storageProducts = db.StorageProducts
				.Where(w => w.StorageId == storageId && products.Keys.ToList().Contains(w.ProductId));

			foreach (var storageProduct in storageProducts)
				storageProduct.DecreaseQuantityOfGoods(products[storageProduct.ProductId]);
		}
	}
}
