using MediatR;
using MerchandiseManager.Application.Contexts.Warehouses.ViewModels;
using System.Collections.Generic;

namespace MerchandiseManager.Application.Contexts.Warehouses.Queries.GetUserWarehouses
{
	public class GetUserWarehousesQuery : IRequest<IEnumerable<WarehouseViewModel>>
	{
	}
}
