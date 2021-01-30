using MerchandiseManager.Register.WPF.Models.Common;
using MerchandiseManager.Register.WPF.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Register.WPF.Services.Api
{
	public class SoldProductsService
	{
		private readonly string apiUrl;

		public SoldProductsService(string apiUrl)
		{
			this.apiUrl = apiUrl;
		}

		public bool SubmitSoldCart(IEnumerable<CartProduct> cartProducts, decimal change, decimal receivedAmount)
		{
			using (var http = new HttpClient())
			{
				http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticDataStorage.AuthToken);

				var response = http.PostAsJsonAsync(apiUrl + "/sold-products", new SubmitSoldCartRequest
				{
					Change = change,
					ReceivedSum = receivedAmount,
					IsWholesale = false,
					SoldProducts = cartProducts.ToDictionary(k => k.ProductId, v => v.Amount)
				}).Result;

				return response.IsSuccessStatusCode;
			}
		}
	}
}
