using Microsoft.Owin.Hosting;
using System;
using System.ServiceProcess;

namespace MerchandiseManager.PrinterService
{
	public partial class PrinterService : ServiceBase
	{
		private IDisposable signalRServer;

		public PrinterService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			signalRServer = WebApp.Start<Startup>("http://*:12669/");
		}

		protected override void OnStop()
		{

		}

		public void Debug(string[] args)
		{
			try
			{
				OnStart(args);
				Console.ReadKey();
				OnStop();
			}
			catch (Exception ex)
			{
			}
		}

		//protected override void Dispose(bool disposing)
		//{
		//	if (signalRServer != null)
		//	{
		//		signalRServer.Dispose();
		//		signalRServer = null;
		//	}

		//	base.Dispose(disposing);
		//}
	}
}
