using System;

namespace MerchandiseManager.LabelPrinterService
{
	public class SignalRServer
	{
		private static readonly Lazy<SignalRServer> lazy = new Lazy<SignalRServer>(() => new SignalRServer());

		public static SignalRServer Instance { get { return lazy.Value; } }

		private SignalRServer() { }


	}
}
