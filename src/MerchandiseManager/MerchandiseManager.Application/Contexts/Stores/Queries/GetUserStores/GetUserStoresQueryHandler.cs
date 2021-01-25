﻿using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Stores.ViewModels;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Stores.Queries.GetUserStores
{
	public class GetUserStoresQueryHandler : IRequestHandler<GetUserStoresQuery, IEnumerable<StoreViewModel>>
	{
		private readonly IDbContext context;
		private readonly ICurrentUser currentUser;
		private readonly IMapper mapper;

		public GetUserStoresQueryHandler(
			IDbContext context,
			ICurrentUser currentUser,
			IMapper mapper)
		{
			this.context = context;
			this.currentUser = currentUser;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<StoreViewModel>> Handle(GetUserStoresQuery request, CancellationToken cancellationToken)
		{
			var storages = await context
				.UserWarehouses
				.Where(w => w.UserId == currentUser.Id)
				.Select(s => s.Warehouse)
				.AsNoTracking()
				.ToListAsync();

			return mapper.Map<List<StoreViewModel>>(storages);
		}
	}
}