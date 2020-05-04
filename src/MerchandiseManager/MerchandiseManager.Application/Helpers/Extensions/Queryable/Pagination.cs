using MerchandiseManager.Application.Interfaces.Models.Filtering;
using System;
using System.Linq;

namespace MerchandiseManager.Application.Helpers.Extensions.Queryable
{
	public static class Pagination
	{
		public static IQueryable<T> Paginate<T>(this IQueryable<T> query, IPaginatable request)
		{
			try
			{
				if (request.Page.HasValue)
				{
					if (request.PageSize.HasValue)
						query = query
							.Skip(request.Page.Value * request.PageSize.Value);
				}

				if (request.PageSize.HasValue)
					query = query
						.Take(request.PageSize.Value);

				return query;
			}
			catch (Exception e)
			{
				throw new Exception("Was an exception in Paginate", e);
			}
		}
	}
}
