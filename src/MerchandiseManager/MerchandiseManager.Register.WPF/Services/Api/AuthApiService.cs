using MerchandiseManager.Register.WPF.Models.Request;
using MerchandiseManager.Register.WPF.Models.Response;
using System.Net.Http;

namespace MerchandiseManager.Register.WPF.Services.Api
{
	public class AuthApiService
	{
		private readonly string apiUrl;

		public AuthApiService(string apiUrl)
		{
			this.apiUrl = apiUrl;
		}

		public bool Authenticate(LoginRequest loginRequest)
		{
			using (var http = new HttpClient())
			{
				var response = http.PostAsJsonAsync(apiUrl + "/auth", loginRequest).Result;

				if (response.IsSuccessStatusCode)
				{
					var result = response.Content.ReadAsAsync<LoginResponse>().Result;

					StaticDataStorage.AuthToken = result.AccessToken;

					return true;
				}

				return false;
			}
		}
	}
}
