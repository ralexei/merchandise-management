using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Storages.Commands.AddNewStorage
{
	public class AddNewStorageCommand : IRequest<Unit>
	{
		public string StorageName { get; set;}
		public string StorageDescription { get; set; }
	}
}
