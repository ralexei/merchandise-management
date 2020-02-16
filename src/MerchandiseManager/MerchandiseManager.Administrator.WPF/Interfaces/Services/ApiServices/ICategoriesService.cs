using MerchandiseManager.Administrator.WPF.Models;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Categories;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices
{
	public interface ICategoriesService
	{
		Task<Category> CreateCategory(AddCategoryDialogViewModel addCAtegoryViewModel);
		Task<FilteredResult<Category>> GetCategories(string searchTerm = "");
	}
}