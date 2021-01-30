using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Register.DAL.TypeHandlers
{
    class GuidTypeHandler : SqliteTypeHandler<Guid>
    {
        public override Guid Parse(object value)
            => Guid.Parse((string)value);
    }
}
