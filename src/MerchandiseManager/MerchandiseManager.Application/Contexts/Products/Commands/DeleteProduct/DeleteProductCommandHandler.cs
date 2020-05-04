using MediatR;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using MerchandiseManager.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
	{
		private readonly IDbContext db;

		public DeleteProductCommandHandler(IDbContext db)
		{
			this.db = db;
		}

		public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var productToDelete = await db.Products
				.FirstOrDefaultAsync(f => f.Id == request.Id);

			if (productToDelete == null)
				throw new EntityNotFoundException(typeof(Product), request.Id.ToString());

			db.Products.Remove(productToDelete);
			await db.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
