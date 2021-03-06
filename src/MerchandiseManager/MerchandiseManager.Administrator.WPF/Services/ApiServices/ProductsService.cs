﻿using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Interfaces.Utils;
using MerchandiseManager.Administrator.WPF.Models;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Products;
using MerchandiseManager.Administrator.WPF.Utils.ObjectExtensions;
using MerchandiseManager.Administrator.WPF.ViewModels.Dialogs.Products;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Services.ApiServices
{
	public class ProductsService : IProductsService
	{
		private readonly IApiConnector apiConnector;

		public ProductsService(IApiConnector apiConnector)
		{
			this.apiConnector = apiConnector;
		}

		public async Task<Product> CreateProduct(AddProductDialogViewModel request)
		{
			return await apiConnector.PostAsync<Product, AddProductDialogViewModel>("products", request);
		}

		public async Task<Product> EditProduct(EditProductViewModel request)
		{
			return await apiConnector.PutAsync<Product, EditProductViewModel>("products", request);
		}

		public async Task<FilteredResult<Product>> GetProducts(ProductsSearchModel request)
		{
			return await apiConnector.GetAsync<FilteredResult<Product>>("products" + request.ToQueryString());
		}
	}
}
