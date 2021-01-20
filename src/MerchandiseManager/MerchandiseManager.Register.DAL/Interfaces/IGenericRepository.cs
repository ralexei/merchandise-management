using DapperExtensions;
using MerchandiseManager.Register.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MerchandiseManager.Register.DAL.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
        T Get<TKey>(TKey id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(IFieldPredicate predicate);

        TKey Add<TKey>(T entity);

        void Add(IEnumerable<T> entities);
        void Update(T entity);
        void Delete<TKey>(TKey id);
    }
}
