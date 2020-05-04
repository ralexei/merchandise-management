using MerchandiseManager.PrinterService.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MerchandiseManager.PrinterService
{
	[HubName("label-printer")]
	public class PrinterHub : Hub
	{
		public static IHubContext HubContext
		{
			get
			{
				if (_context == null)
					_context = GlobalHost.ConnectionManager.GetHubContext<PrinterHub>();

				return _context;
			}
		}
		static IHubContext _context = null;

		public bool PrintLabel(PrintRequest request)
		{
			return true;
		}
	}
}
