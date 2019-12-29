using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Models.Config
{
	public class JwtSettings
	{
		public string Secret { get; set; }
		public int ExpirationMinutes { get; set; }
	}
}
