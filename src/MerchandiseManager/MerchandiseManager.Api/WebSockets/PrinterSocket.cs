using WebSocketSharp;
using WebSocketSharp.Server;

namespace MerchandiseManager.Api.WebSockets
{
	public class PrinterSocket : WebSocketBehavior
	{
		protected override void OnMessage(MessageEventArgs e)
		{
			
			base.OnMessage(e);
		}
	}
}
