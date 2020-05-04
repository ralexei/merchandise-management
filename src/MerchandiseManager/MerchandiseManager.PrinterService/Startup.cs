using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(MerchandiseManager.PrinterService.Startup))]

namespace MerchandiseManager.PrinterService
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.Map("/signalr", map =>
			{
				map.UseCors(CorsOptions.AllowAll);

				var hubConfiguration = new HubConfiguration
				{
					EnableDetailedErrors = true
				};

				map.RunSignalR(hubConfiguration);
			});
		}
	}
}
