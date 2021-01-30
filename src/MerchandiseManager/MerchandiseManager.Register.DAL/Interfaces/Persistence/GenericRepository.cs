using System;
using System.Collections.Generic;
using DapperExtensions;
using MerchandiseManager.Register.DAL.Entities;
using Microsoft.Data.Sqlite;

namespace MerchandiseManager.Register.DAL.Interfaces.Persistence
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		protected readonly string connectionString;

		public GenericRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public TKey Add<TKey>(T entity)
		{
			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();

				var result = connection.Insert(entity);

				connection.Close();
				return (TKey)result;
			}
		}

		public void Add(IEnumerable<T> entities)
		{
			using (var connection = new SqliteConnection(connectionString))
			{
				try
				{
					connection.Open();
					connection.Insert(entities);
					connection.Close();
				}
				catch (Exception)
				{
					connection.Close();
				}
			}
		}

		public void Delete<TKey>(TKey id)
		{
			using (var connection = new SqliteConnection(connectionString))
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
			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();

				var entity = connection.Get<T>(id);

				connection.Close();

				return entity;
			}
		}

		public IEnumerable<T> GetAll()
		{
			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();

				var data = connection.GetList<T>();

				connection.Close();

				return data;
			}
		}

		public IEnumerable<T> GetAll(IFieldPredicate predicate)
		{
			using (var connection = new SqliteConnection(connectionString))
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
