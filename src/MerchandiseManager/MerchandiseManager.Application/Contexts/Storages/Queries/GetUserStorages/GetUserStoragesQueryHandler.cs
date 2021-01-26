using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Storages.ViewModels;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Storages.Queries.GetUserStorages
{
	public class GetUserStoragesQueryHandler : IRequestHandler<GetUserStoragesQuery, IEnumerable<StorageViewModel>>
	{
		private readonly IDbContext context;
		private readonly ICurrentUser currentUser;
		private readonly IMapper mapper;

		public GetUserStoragesQueryHandler(
			IDbContext context,
			ICurrentUser currentUser,
			IMapper mapper)
		{
			this.context = context;
			this.currentUser = currentUser;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<StorageViewModel>> Handle(GetUserStoragesQuery request, CancellationToken cancellationToken)
		{
			var storages = await context
				.UserStorages
				.Where(w => w.UserId == currentUser.Id)
				.Select(s => s.Storage)
				.ToListAsync();

			return mapper.Map<List<StorageViewModel>>(storages);
		}
	}
}
