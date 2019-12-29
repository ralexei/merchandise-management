using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Utility.Extensions
{
	public static class DateTimeExtensions
	{
		public static long ToUnixTimestamp(this DateTime dt)
		{
			return (long)dt.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}
	}
}
