using MediatR;
using MerchandiseManager.Application.Contexts.Warehouses.ViewModels;

namespace MerchandiseManager.Application.Contexts.Warehouses.Commands.AddNewStorage
{
	public class AddNewWarehouseCommand : IRequest<WarehouseViewModel>
	{
		public string Name { get; set;}
		public string Description { get; set; }
	}
}
