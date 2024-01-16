using System;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseManager.PrinterService.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MerchandiseManager.LabelPrinterService
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly BarcodeLabelGenerator _barcodeGenerator;

		public Worker(ILogger<Worker> logger, BarcodeLabelGenerator barcodeGenerator)
		{
			_logger = logger;
			_barcodeGenerator = barcodeGenerator;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var bm = _barcodeGenerator.GenerateLabelImage(new PrinterService.Models.PrintRequest
			{
				BarcodeToPrint = "123123123",
				LabelsCount = 1,
				PrintingProduct = new PrintingProductData
				{
					Price = 1332.32m,
					ProductName = "Product Name"
				}
			});
			
			while (!stoppingToken.IsCancellationRequested)
			{
				_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
				await Task.Delay(1000, stoppingToken);
			}
		}
	}
}
