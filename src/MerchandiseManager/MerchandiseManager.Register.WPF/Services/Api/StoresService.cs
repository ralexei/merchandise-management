using MerchandiseManager.Register.WPF.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Register.WPF.Services.Api
{
	public class StoresService
	{
		private readonly string apiUrl;

		public StoresService(string apiUrl)
		{
			this.apiUrl = apiUrl;
		}

		public IEnumerable<StorageViewModel> GetStores()
		{
			using (var http = new HttpClient())
			{
				var response = http.GetAsync(apiUrl + "/stores").Result;
				
				return response.Content.ReadAsAsync<List<StorageViewModel>>().Result;
			}
		}
	}
}
