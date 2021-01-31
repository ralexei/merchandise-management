using System;

namespace MerchandiseManager.Register.WPF.Models.Request
{
	public class LoginRequest
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public Guid StoreId { get; set; }
	}
}
