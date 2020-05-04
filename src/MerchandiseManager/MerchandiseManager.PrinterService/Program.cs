using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseManager.PrinterService
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			var serv = new PrinterService();
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[]
			{
				serv
			};
			if (args != null && args.Length > 0 && args[0] == "-debug")
			{
				serv.Debug(args);
			}
			else if (Environment.UserInteractive)
			{
				try
				{
					ManagedInstallerClass.InstallHelper(new[] { typeof(Program).Assembly.Location });
				}
				catch (Exception e)
				{
				}
				Console.WriteLine(@"Press any key to exit...");
				Console.ReadKey();
			}
			else
			{
				ServiceBase.Run(ServicesToRun);
			}
		}
	}
}
