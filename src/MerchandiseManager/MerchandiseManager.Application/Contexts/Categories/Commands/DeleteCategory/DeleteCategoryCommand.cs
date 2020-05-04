using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Categories.Commands.DeleteCategory
{
	public class DeleteCategoryCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }

		public DeleteCategoryCommand(Guid id)
		{
			Id = id;
		}
	}
}
