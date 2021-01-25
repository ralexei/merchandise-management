using MediatR;
using MerchandiseManager.Application.Contexts.Stores.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Stores.Queries.GetUserStores
{
	public class GetUserStoresQuery : IRequest<IEnumerable<StoreViewModel>>
	{
	}
}
