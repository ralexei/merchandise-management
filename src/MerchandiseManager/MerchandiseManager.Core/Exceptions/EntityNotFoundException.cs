using System;
using System.Net;

namespace MerchandiseManager.Core.Exceptions
{
	public class EntityNotFoundException : BaseException
	{
		public EntityNotFoundException() : base(HttpStatusCode.NotFound, "entityNotFound") { }

		public EntityNotFoundException(string message) : base(HttpStatusCode.NotFound, "entityNotFound", message) { }

		public EntityNotFoundException(Exception inner) : base(HttpStatusCode.NotFound, "entityNotFound", inner: inner) { }

		public EntityNotFoundException(string message, Exception inner) : base(HttpStatusCode.NotFound, "entityNotFound", message, inner) { }
		public EntityNotFoundException(Type type, string searchCriteria, Exception inner = null)
			: base(HttpStatusCode.NotFound, "entityNotFound", $"{type.Name} ('{searchCriteria}') not found", inner) { }
	}
}
