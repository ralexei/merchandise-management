using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Utility.Extensions
{
	public static class StringExtensions
	{
		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}
	}
}
