using MediatR;
using AutoMapper;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseManager.Application.Interfaces.Authentication;

namespace MerchandiseManager.Application.Contexts.Storages.Commands.AddNewStorage
{
	public class AddNewStorageCommandHandler : IRequestHandler<AddNewStorageCommand, Unit>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;
		private readonly ICurrentUser currentUser;

		public AddNewStorageCommandHandler(IDbContext db, IMapper mapper, ICurrentUser currentUser)
		{
			this.db = db;
			this.mapper = mapper;
			this.currentUser = currentUser;
		}

		public async Task<Unit> Handle(AddNewStorageCommand request, CancellationToken cancellationToken)
		{
			var newStorage = mapper.Map<Storage>(request);

			newStorage.UserStorages.Add(new UserStorage(currentUser.Id));

			await db.Storages.AddAsync(newStorage);
			await db.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
