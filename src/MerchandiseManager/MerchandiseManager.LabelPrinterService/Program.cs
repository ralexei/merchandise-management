using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace MerchandiseManager.LabelPrinterService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder
						.UseUrls()
						.UseKestrel()
						.ConfigureKestrel(kestrel =>
						{
							kestrel.ListenLocalhost(12669);
						})
						.UseStartup<Startup>();
				})
				.UseWindowsService();
	}
}
