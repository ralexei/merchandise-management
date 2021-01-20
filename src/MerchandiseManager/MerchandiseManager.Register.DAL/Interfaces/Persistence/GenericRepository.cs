using System.Collections.Generic;
using System.Data.SqlClient;
using DapperExtensions;
using Microsoft.CSharp.RuntimeBinder;
using MerchandiseManager.Register.DAL.Entities;

namespace MerchandiseManager.Register.DAL.Interfaces.Persistence
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly string connectionString;

		public GenericRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public TKey Add<TKey>(T entity)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var result = connection.Insert(entity);

				connection.Close();
				return (TKey)result;
			}
		}

		public void Add(IEnumerable<T> entities)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				connection.Insert(entities);
				connection.Close();
			}
		}

		public void Delete<TKey>(TKey id)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				
				var entity = connection.Get<T>(id);
			
				if (entity != null)
					connection.Delete(entity);

				connection.Close();

				return;
			}
		}

		public T Get<TKey>(TKey id)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var entity = connection.Get<T>(id);

				connection.Close();

				return entity;
			}
		}

		public IEnumerable<T> GetAll()
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var data = connection.GetList<T>();

				connection.Close();

				return data;
			}
		}

		public IEnumerable<T> GetAll(IFieldPredicate predicate)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				
				var data = connection.GetList<T>(predicate);

				connection.Close();

				return null;
			}
		}

		public void Update(T entity)
		{

		}
	}
}
