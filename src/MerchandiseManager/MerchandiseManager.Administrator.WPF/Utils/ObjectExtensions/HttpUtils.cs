using System;
using System.Linq;
using System.Text;

namespace MerchandiseManager.Administrator.WPF.Utils.ObjectExtensions
{
	public static class HttpUtils
	{
		public static string ToQueryString(this object obj)
		{
			var qs = new StringBuilder("?");

			var objType = obj.GetType();

			objType.GetProperties()
				   .Where(p => p.GetValue(obj, null) != null)
				   .ToList()
				   .ForEach(p => qs.Append($"{Uri.EscapeDataString(p.Name)}={Uri.EscapeDataString(p.GetValue(obj).ToString())}&"));

			return qs.ToString();
		}
	}
}
