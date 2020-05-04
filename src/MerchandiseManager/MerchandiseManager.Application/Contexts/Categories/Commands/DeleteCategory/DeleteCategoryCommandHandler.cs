using MediatR;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using MerchandiseManager.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Categories.Commands.DeleteCategory
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
	{
		private readonly IDbContext db;

		public DeleteCategoryCommandHandler(IDbContext db)
		{
			this.db = db;
		}

		public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			var categoryToRemove = await db.Categories.FirstOrDefaultAsync(f => f.Id == request.Id);

			if (categoryToRemove == null)
				throw new EntityNotFoundException(typeof(Category), request.Id.ToString());

			db.Categories.Remove(categoryToRemove);
			await db.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
