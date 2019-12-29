using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Core.Models.ResponseObjects.Common
{
	public class ErrorResponse
	{
		public int StatusCode { get; private set; }
		public string ErrorId { get; private set; }
		public string Message { get; private set; }

		public ErrorResponse(int statusCode, string errorId, string message)
		{
			StatusCode = statusCode;
			ErrorId = errorId;
			Message = message;
		}

		public ErrorResponse(int statusCode, string errorId) : this(statusCode, errorId, "") { }
	}
}
