using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Warehouses.Commands.ReplenishStorage
{
	public class ReplenishStorageCommand : IRequest<Unit>
	{
		public Guid DestinationStorageId { get; set; }
		public Guid? SourceStorageId { get; set; }
		public Dictionary<Guid, int> Products { get; set; }
	}
}
