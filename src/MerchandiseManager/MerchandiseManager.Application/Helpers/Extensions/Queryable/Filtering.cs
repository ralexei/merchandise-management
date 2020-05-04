using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MerchandiseManager.Application.Helpers.Extensions.Queryable
{
	public static class Filtering
	{
		public static IQueryable<TEntity> FilterMinMax<TEntity,TRequest>(this IQueryable<TEntity> query, TRequest request)
		{
			try
			{
				if (request == null) return query;

				var properties = typeof(TRequest)
					.GetProperties(BindingFlags.Public | BindingFlags.Instance)
					.Where(property => (property.Name.EndsWith("Max") || property.Name.EndsWith("Min"))
									   && Nullable.GetUnderlyingType(property.PropertyType) != null
									   && property.GetValue(request, null) != null);

				var objParam = Expression.Parameter(typeof(TEntity), "obj");

				Expression operation = null;

				foreach (var property in properties)
				{
					var propertyMember = Expression.Property(objParam, property.Name.Substring(0, property.Name.Length - 3));
					var val = property.GetValue(request);

                    Expression colOperation = property.Name.EndsWith("Max")
                       ? Expression.LessThanOrEqual(propertyMember, Expression.Constant(val, propertyMember.Type))
                       : Expression.GreaterThanOrEqual(propertyMember, Expression.Constant(val, propertyMember.Type));

					operation = operation != null
						? Expression.AndAlso(operation, colOperation)
						: colOperation;
				}

				return query.Where(operation != null
					? Expression.Lambda<Func<TEntity, bool>>(operation, objParam)
					: (u) => true);
			}
			catch(Exception e)
			{
				throw new Exception("Was An exception in FilterMinMax", e);
			}
		}

		public static IQueryable<TEntity> FilterContaing<TEntity, TRequest>(this IQueryable<TEntity> query, TRequest request)
		{
			try
			{
				if (request == null)
					return query;

				var properties = typeof(TRequest)
					.GetProperties(BindingFlags.Public | BindingFlags.Instance)
					.Where(property => (property.Name.EndsWith("Contains"))
										&& (Nullable.GetUnderlyingType(property.PropertyType) != null || property.PropertyType == typeof(string))
										&& property.GetValue(request, null) != null);
				var objParam = Expression.Parameter(typeof(TEntity), "obj");

				Expression operation = null;

				foreach (var property in properties)
				{
					var propertyMember = Expression.Property(objParam, property.Name.Substring(0, property.Name.Length - 8));
					var val = property.GetValue(request);

					var colOperation = propertyMember.Type.IsEnum
						? Expression.Equal(propertyMember, Expression.Constant(val, propertyMember.Type))
						: CreateLike<TEntity>(propertyMember, val.ToString());

					var nullCheck = Expression.NotEqual(propertyMember, Expression.Constant(null, typeof(object)));
					colOperation = Expression.AndAlso(nullCheck, colOperation);

					operation = operation != null
						? Expression.AndAlso(operation, colOperation)
						: colOperation;
				}

				return query.Where(operation != null
					? Expression.Lambda<Func<TEntity, bool>>(operation, objParam)
					: (u) => true);
			}
            catch (Exception e)
			{
				throw new Exception("Was an exception in FilterContaing", e);
			}
			
		}

		private static BinaryExpression CreateLike<T>(MemberExpression prop, string value, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
		{
            var indexOf = Expression.Call(prop, "IndexOf", null,
                Expression.Constant(value, typeof(string)));

            return Expression.GreaterThanOrEqual(indexOf, Expression.Constant(0));
        }
	}
}
