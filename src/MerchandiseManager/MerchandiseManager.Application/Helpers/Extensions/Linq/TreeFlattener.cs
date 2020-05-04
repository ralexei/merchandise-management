using System;
using System.Collections.Generic;
using System.Linq;

namespace MerchandiseManager.Application.Helpers.Extensions.Linq
{
	public static class TreeFlattener
	{
		public static IEnumerable<TFlat> Flatten<T, TFlat>(
			this IEnumerable<T> e,
			Func<T, IEnumerable<T>> f,
			Func<TFlat, uint, TFlat> setLevel,
			Func<T, TFlat> map,
			uint level = 0)
		{
			return e.SelectMany(c => new List<TFlat> { setLevel(map(c), level) }.Concat(f(c).Flatten(f, setLevel, map, level + 1)));
		}

		public static IEnumerable<T> Flatten<T>(
			this IEnumerable<T> e,
			Func<T, IEnumerable<T>> f)
		{
			return e.SelectMany(c => new List<T> { c }.Concat(f(c).Flatten(f)));
		}
	}
}
