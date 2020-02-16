using System.Configuration;

namespace MerchandiseManager.Administrator.WPF.Utils
{
	public static class AppConfigManager
	{
		public static string ApiUrl => ConfigurationManager.AppSettings.Get("ApiUrl");
	}
}
