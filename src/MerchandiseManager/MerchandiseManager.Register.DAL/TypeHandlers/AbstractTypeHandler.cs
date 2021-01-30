using Dapper;
using System.Data;

namespace MerchandiseManager.Register.DAL.TypeHandlers
{
	abstract class SqliteTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        public override void SetValue(IDbDataParameter parameter, T value)
            => parameter.Value = value;
    }
}
