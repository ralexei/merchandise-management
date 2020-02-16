using MediatR;
using MerchandiseManager.Application.Contexts.Categories.ViewModels;
using System;

namespace MerchandiseManager.Application.Contexts.Categories.Commands.CreateCategory
{
	public class CreateCategoryCommand : IRequest<CategoryViewModel>
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public Guid? ParentId { get; set; }
	}
}
