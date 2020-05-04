using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Categories;
using MerchandiseManager.Administrator.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products
{
	public class AddCategoryDialogViewModel : BaseDialogViewModel
	{
		private readonly ICategoriesService categoriesService;

		public ICommand CategorySelectedCommand { get; set; }
		public ICommand CreateCategoryCommand { get; set; }

		public List<Category> Categories { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public Guid? ParentId { get; set; }

		public Category CreatedCategory { get; private set; }

		public AddCategoryDialogViewModel(ICategoriesService categoriesService)
		{
			CategorySelectedCommand = new RelayParameterizedCommand((selectedCategory) => SelectCategory((Category)selectedCategory));
			CreateCategoryCommand = new RelayCommand(async () => await CreateCategory());

			this.categoriesService = categoriesService;

			GetCategories();
		}

		private void SelectCategory(Category category)
		{
			ParentId = category.Id;
		}

		private async Task CreateCategory()
		{
			try
			{
				CreatedCategory = await categoriesService.CreateCategory(this);


				Window.DialogResult = true;
			}
			catch { }
		}

		private async void GetCategories()
		{
			Categories = (await categoriesService.GetCategories()).Data.ToList();
		}
	}
}
