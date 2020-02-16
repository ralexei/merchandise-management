using System.Collections.Generic;

namespace MerchandiseManager.Administrator.WPF.Models
{
	public class FilteredResult<T>
	{
		public int Total { get; private set; }
		public int Length { get; private set; }

		public IEnumerable<T> Data { get; private set; }

		public FilteredResult(IEnumerable<T> data, int total, int length)
		{
			Total = total;
			Length = length;
			Data = data;
		}
	}
}
