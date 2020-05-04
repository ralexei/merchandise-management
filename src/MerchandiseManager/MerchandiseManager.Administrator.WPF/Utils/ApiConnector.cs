using MerchandiseManager.Administrator.WPF.Interfaces.Utils;
using MerchandiseManager.Administrator.WPF.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Utils
{
	public class ApiConnector : IApiConnector
	{
		private readonly HttpClient _client;

		public ApiConnector()
		{
			_client = new HttpClient();

			if (!string.IsNullOrEmpty(DataStore.Instance.AccessToken))
				_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {DataStore.Instance.AccessToken}");

			SetBaseAddress(AppConfigManager.ApiUrl);
		}

		public void SetBaseAddress(string address)
		{
			if (address[address.Length - 1] != '/')
				address += '/';

			_client.BaseAddress = new Uri(address);
		}

		public async Task<T> GetAsync<T>(string path)
		{
			var res = await _client.GetAsync(path).ConfigureAwait(false);

			res.EnsureSuccessStatusCode();

			return await res.Content.ReadAsAsync<T>();
		}

		public async Task<TResult> PostAsync<TResult, TInput>(string path, TInput obj)
		{
			var res = await _client.PostAsJsonAsync(path, obj).ConfigureAwait(false);

			if (res.StatusCode == HttpStatusCode.OK || res.StatusCode == HttpStatusCode.Created)
			{
				return await res.Content.ReadAsAsync<TResult>();
			}
			else if (res.StatusCode == HttpStatusCode.BadRequest)
			{
				var errorMsg = await res.Content.ReadAsStringAsync();

				throw new ArgumentException();
			}
			else
				throw new Exception("Unknown error");
		}

		public async Task PostAsync<TInput>(string path, TInput obj)
		{
			var result = await _client.PostAsJsonAsync(path, obj);
			
			result.EnsureSuccessStatusCode();
		}

		public async Task<TResult> PostAsync<TResult>(string path)
		{
			var res = await _client.PostAsync(path, new StringContent(string.Empty));

			res.EnsureSuccessStatusCode();

			return await res.Content.ReadAsAsync<TResult>();
		}

		public async Task PostAsync(string path)
		{
			await _client.PostAsync(path, new StringContent(string.Empty));
		}

		public async Task<TResult> PutAsync<TResult, TInput>(string path, TInput obj)
		{
			var res = await _client.PutAsJsonAsync(path, obj);

			res.EnsureSuccessStatusCode();

			return await res.Content.ReadAsAsync<TResult>();
		}

		public async Task<HttpStatusCode> PutAsync<T>(string path, T obj)
		{
			return (await _client.PutAsJsonAsync(path, obj)).StatusCode;
		}

		public async Task<HttpStatusCode> DeleteAsync(string path)
		{
			return (await _client.DeleteAsync(path)).StatusCode;
		}


		//Dispose implementation
		#region DISPOSE_IMPLEMENTATION
		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				_client.Dispose();
			}
			disposed = true;
		}

		bool disposed = false;
		#endregion
	}
}
