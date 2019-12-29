using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Authorization.Commands.SignIn
{
	public class SignInCommand : IRequest<string>
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
