using MerchandiseManager.Application.Interfaces.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchandiseManager.Application.Helpers.Extensions.Queryable
{
	public static class Pagination
	{
		public static IQueryable<T> Paginate<T>(this IQueryable<T> query, IPaginatable request)
		{
			try
			{
				if (request.Start.HasValue)
					query = query.Skip(request.Start.Value);

				if (request.Limit.HasValue)
					query = query.Take(request.Limit.Value);

				return query;
			}
			catch (Exception e)
			{
				throw new Exception("Was an exception in Paginate", e);
			}
		}
	}
}
