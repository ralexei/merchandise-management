using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Stores.Commands.AddNewStore
{
	public class AddNewStoreCommandHandler : IRequestHandler<AddNewStoreCommand, Unit>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;

		public AddNewStoreCommandHandler(IDbContext db, IMapper mapper)
		{
			this.db = db;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(AddNewStoreCommand request, CancellationToken cancellationToken)
		{
			var newStore = mapper.Map<Store>(request);

			await db.Stores.AddAsync(newStore);
			await db.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
