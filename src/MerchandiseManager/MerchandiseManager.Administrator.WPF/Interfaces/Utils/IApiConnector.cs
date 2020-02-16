using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Interfaces.Utils
{
	public interface IApiConnector : IDisposable
	{
		Task<T> GetAsync<T>(string path);

		Task<TResult> PostAsync<TResult, TInput>(string path, TInput obj);

		Task PostAsync<TInput>(string path, TInput obj);

		Task<TResult> PostAsync<TResult>(string path);

		Task PostAsync(string path);

		Task<TResult> PutAsync<TResult, TInput>(string path, TInput obj);

		Task<HttpStatusCode> PutAsync<T>(string path, T obj);

		Task<HttpStatusCode> DeleteAsync(string path);
	}
}
