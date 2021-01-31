using MerchandiseManager.Register.WPF.Interfaces.ApiServices;
using MerchandiseManager.Register.WPF.Models.Response;
using MerchandiseManager.Register.WPF.Persistence.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MerchandiseManager.Register.WPF.Services.Api
{
	public class ProductsApiService : IProductsService
	{
		private readonly string apiUrl;

		public ProductsApiService(string apiUrl)
		{
			this.apiUrl = apiUrl;
		}

		public FilteredResult<Product> GetAllProducts()
		{
			using (var http = new HttpClient())
			{
				http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticDataStorage.AuthToken);

				var response = http.GetAsync(apiUrl + "/products").Result;

				return response.Content.ReadAsAsync<FilteredResult<Product>>().Result;
			}
		}

		public IEnumerable<ProductAvailabilityViewModel> GetProductAvailability(string productSearchTerm)
		{
			using (var http = new HttpClient())
			{
				http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticDataStorage.AuthToken);

				var response = http.GetAsync($"{apiUrl}/products/available?productSearchTerm={productSearchTerm}").Result;

				return response.Content.ReadAsAsync<List<ProductAvailabilityViewModel>>().Result;
			}
		}
	}
}
