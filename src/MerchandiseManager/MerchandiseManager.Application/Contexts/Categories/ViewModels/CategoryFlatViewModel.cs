using System;

namespace MerchandiseManager.Application.Contexts.Categories.ViewModels
{
	public class CategoryFlatViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		public uint NestingLevel { get; set; }
	}
}
