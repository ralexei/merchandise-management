using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Warehouses.Commands.ReplenishStorage
{
	public class ReplenishWarehouseCommand : IRequest<Unit>
	{
		public Guid StorageId { get; set; }
		public Dictionary<Guid, int> Products { get; set; }
	}
}
