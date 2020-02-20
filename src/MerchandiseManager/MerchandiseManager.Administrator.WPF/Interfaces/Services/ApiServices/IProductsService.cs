using MerchandiseManager.Administrator.WPF.Models;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Products;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices
{
	public interface IProductsService
	{
		Task<Product> CreateProduct(AddProductDialogViewModel request);
		Task<Product> EditProduct(EditProductViewModel request);
		Task<FilteredResult<Product>> GetProducts();
	}
}
