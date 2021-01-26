using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.StorageProducts.Commands.DeleteStorageProduct
{
	public class DeleteStorageProductCommand : IRequest
	{
		public Guid StorageId { get; set; }
		public Guid ProductId { get; set; }
	}
}
