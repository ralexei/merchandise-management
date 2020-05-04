using MerchandiseManager.Api.WebSockets;
using MerchandiseManager.Application.Models.Config;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace MerchandiseManager.Api.BackgroundServices
{
	public class PrinterSocketService : BackgroundService
	{
		private readonly WebSocketServer socketServer;

		public PrinterSocketService(IOptions<AppSettings> appSettings)
		{
			socketServer = new WebSocketServer(appSettings.Value.PrinterSocketPort);

			socketServer.AddWebSocketService<PrinterSocket>("/printer");
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			socketServer.Start();

			await Task.CompletedTask;
		}

		public override async Task StopAsync(CancellationToken cancellationToken)
		{
			socketServer.Stop();

			await Task.CompletedTask;
		}
	}
}
