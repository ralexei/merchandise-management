using MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices;
using MerchandiseManager.Administrator.WPF.Interfaces.Utils;
using MerchandiseManager.Administrator.WPF.Models.ViewModels.Auth;
using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Services.ApiServices
{
	public class AuthService : IAuthService
	{
		private readonly IApiConnector apiConnector;

		public AuthService(IApiConnector apiConnector)
		{
			this.apiConnector = apiConnector;
		}

		public void Login(string username, string password)
		{
			var token = apiConnector.PostAsync<LoginResult, object>("auth", new { UserName = username, Password = password }).Result;

			DataStore.Instance.AccessToken = token.AccessToken;
		}
	}
}
