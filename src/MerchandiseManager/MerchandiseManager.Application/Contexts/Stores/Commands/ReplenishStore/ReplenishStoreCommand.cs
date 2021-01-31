using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Stores.Commands.ReplenishStore
{
	public class ReplenishStoreCommand : IRequest
	{
		public Guid StoreId { get; set; }
		public Dictionary<Guid, int> Products { get; set; }
	}
}
