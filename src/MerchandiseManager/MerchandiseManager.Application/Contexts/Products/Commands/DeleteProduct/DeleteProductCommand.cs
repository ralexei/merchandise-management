using MediatR;
using System;

namespace MerchandiseManager.Application.Contexts.Products.Commands.DeleteProduct
{
	public class DeleteProductCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }

		public DeleteProductCommand(Guid id)
		{
			Id = id;
		}
	}
}
