using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseManager.LabelPrinterService
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();
			services.AddSignalR(opt =>
			{
				opt.EnableDetailedErrors = true;
			});
			services.AddHostedService<Worker>();
			services.AddSingleton<BarcodeLabelGenerator>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//if (env.IsDevelopment())
			//{
			//	app.UseDeveloperExceptionPage();
			//}
			app.UseRouting();
			app.UseCors(opt =>
			{
				opt
				.WithOrigins("http://localhost:4200", "http://116.203.19.248")
				.AllowAnyHeader()
				.AllowCredentials();
			});
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<PrinterHub>("hubs/label-printer");
			});
		}
	}
}
