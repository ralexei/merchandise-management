﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Models.Filtering
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
