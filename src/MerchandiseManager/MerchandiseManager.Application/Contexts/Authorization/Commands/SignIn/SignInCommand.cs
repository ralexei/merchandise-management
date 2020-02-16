using MediatR;
using MerchandiseManager.Application.Contexts.Authorization.ViewModels;
using System;

namespace MerchandiseManager.Application.Contexts.Authorization.Commands.SignIn
{
	public class SignInCommand : IRequest<SignInResult>
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public Guid StoreId { get; set; }
	}
}
