using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Stores.Commands.AddNewStore
{
	public class AddNewStoreCommand : IRequest<Unit>
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
