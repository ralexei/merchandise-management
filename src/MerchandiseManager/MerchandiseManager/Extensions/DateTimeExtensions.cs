using System;

namespace MerchandiseManager.Utility.Extensions
{
	public static class DateTimeExtensions
	{
		public static long ToUnixTimestamp(this DateTime dt)
		{
			return (long)dt.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}

		public static DateTime ToDate(this long unixTimestamp)
		{
			var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

			dtDateTime = dtDateTime.AddSeconds(unixTimestamp).ToLocalTime();

			return dtDateTime;
		}
	}
}
