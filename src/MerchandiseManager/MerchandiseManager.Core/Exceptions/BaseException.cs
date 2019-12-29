using MerchandiseManager.Core.Models.ResponseObjects.Common;
using System;
using System.Net;

namespace MerchandiseManager.Core.Exceptions
{
	public class BaseException : Exception
	{
		protected HttpStatusCode StatusCode { get; private set; }
		protected string ErrorId { get; private set; }

		public BaseException(HttpStatusCode statusCode, string errorId, string message = "", Exception inner = null) : base(message, inner)
		{
			StatusCode = statusCode;
			ErrorId = errorId;
		}

		public BaseException(HttpStatusCode statusCode, string errorId) : this(statusCode, errorId, "Unhandled exception") { }

		public ErrorResponse ToErrorObject(BaseException ex)
		{
			return new ErrorResponse((int)ex.StatusCode, ex.ErrorId);
		}
	}
}
