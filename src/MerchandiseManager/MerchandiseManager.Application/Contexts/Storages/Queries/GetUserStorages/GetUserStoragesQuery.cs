using MediatR;
using MerchandiseManager.Application.Contexts.Storages.ViewModels;
using System.Collections.Generic;

namespace MerchandiseManager.Application.Contexts.Storages.Queries.GetUserStorages
{
	public class GetUserStoragesQuery : IRequest<IEnumerable<StorageViewModel>>
	{
	}
}
