using MediatR;
using MerchandiseManager.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.StorageProducts.Commands.DeleteStorageProduct
{
	public class DeleteStorageProductCommandHandler : IRequestHandler<DeleteStorageProductCommand>
	{
		private readonly IDbContext context;

		public DeleteStorageProductCommandHandler(IDbContext context)
		{
			this.context = context;
		}

		public async Task Handle(DeleteStorageProductCommand request, CancellationToken cancellationToken)
		{
			var storageProductsToRemove = await context
				.StorageProducts
				.FirstOrDefaultAsync(w => w.StorageId == request.StorageId && w.ProductId == request.ProductId);

			context.StorageProducts.Remove(storageProductsToRemove);
			await context.SaveChangesAsync(cancellationToken);
		}
	}
}
