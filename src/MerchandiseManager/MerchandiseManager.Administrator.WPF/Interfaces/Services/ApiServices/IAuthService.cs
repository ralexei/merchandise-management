using System.Threading.Tasks;

namespace MerchandiseManager.Administrator.WPF.Interfaces.Services.ApiServices
{
	public interface IAuthService
	{
		void Login(string username, string password);
	}
}
