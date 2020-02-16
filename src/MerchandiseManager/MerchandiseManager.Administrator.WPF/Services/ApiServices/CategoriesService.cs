using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Interfaces.Utils;
using MerchandiseManager.Administrator.WPF.Models;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Categories;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using System;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Services.ApiServices
{
	public class CategoriesService : ICategoriesService
	{
		private readonly IApiConnector apiConnector;

		public CategoriesService(IApiConnector apiConnector)
		{
			this.apiConnector = apiConnector;
		}

		public async Task<Category> CreateCategory(AddCategoryDialogViewModel addCategoryViewModel)
		{
			return await apiConnector.PostAsync<Category, AddCategoryDialogViewModel>("categories", addCategoryViewModel);
		}

		public async Task<FilteredResult<Category>> GetCategories(string searchTerm = "")
		{
			return await apiConnector.GetAsync<FilteredResult<Category>>($"categories?nameContains{searchTerm}");
		}
	}
}
