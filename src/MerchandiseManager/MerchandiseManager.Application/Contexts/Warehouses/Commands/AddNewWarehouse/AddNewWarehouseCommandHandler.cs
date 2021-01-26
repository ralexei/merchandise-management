using MediatR;
using AutoMapper;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Contexts.Warehouses.ViewModels;

namespace MerchandiseManager.Application.Contexts.Warehouses.Commands.AddNewStorage
{
	public class AddNewWarehouseCommandHandler : IRequestHandler<AddNewWarehouseCommand, WarehouseViewModel>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;
		private readonly ICurrentUser currentUser;

		public AddNewWarehouseCommandHandler(IDbContext db, IMapper mapper, ICurrentUser currentUser)
		{
			this.db = db;
			this.mapper = mapper;
			this.currentUser = currentUser;
		}

		public async Task<WarehouseViewModel> Handle(AddNewWarehouseCommand request, CancellationToken cancellationToken)
		{
			var newStorage = mapper.Map<Warehouse>(request);

			await db.Warehouses.AddAsync(newStorage);
			await db.UserStorages.AddAsync(new UserStorage(currentUser.Id, newStorage));

			await db.SaveChangesAsync(cancellationToken);

			return mapper.Map<WarehouseViewModel>(newStorage);
		}
	}
}
