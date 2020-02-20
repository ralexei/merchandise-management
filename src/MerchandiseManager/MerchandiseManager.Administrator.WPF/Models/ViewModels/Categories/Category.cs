using System;
using System.Collections.Generic;

namespace MerchandiseManager.Administrator.WPF.Models.ViewModels.Categories
{
	public class Category
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		public List<Category> Children { get; set; }

		public bool IsSelected { get; set; }
		public bool IsExpanded { get; set; }
	}
}
