using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Warehouses.ViewModels;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Warehouses.Queries.GetUserWarehouses
{
	public class GetUserWarehousesQueryHandler : IRequestHandler<GetUserWarehousesQuery, IEnumerable<WarehouseViewModel>>
	{
		private readonly IDbContext context;
		private readonly ICurrentUser currentUser;
		private readonly IMapper mapper;

		public GetUserWarehousesQueryHandler(
			IDbContext context,
			ICurrentUser currentUser,
			IMapper mapper)
		{
			this.context = context;
			this.currentUser = currentUser;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<WarehouseViewModel>> Handle(GetUserWarehousesQuery request, CancellationToken cancellationToken)
		{
			var storages = await context
				.Warehouses
				.Where(w => w.UserId == currentUser.Id)
				.AsNoTracking()
				.ToListAsync();

			return mapper.Map<List<WarehouseViewModel>>(storages);
		}
	}
}
