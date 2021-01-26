using MediatR;
using MerchandiseManager.Application.Contexts.Authorization.ViewModels;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Authorization.Commands.SignIn
{
	public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResult>
	{
		private readonly IDbContext db;
		private readonly IJwtHandler jwtHandler;

		public SignInCommandHandler(IDbContext db, IJwtHandler jwtHandler)
		{
			this.db = db;
			this.jwtHandler = jwtHandler;
		}

		public async Task<SignInResult> Handle(SignInCommand request, CancellationToken cancellationToken)
		{
			var user = db
				.Users
				.FirstOrDefault(f => f.Username == request.Username);

			if (!user.IsPasswordValid(request.Password))
				throw new ArgumentException(); //@TODO-UNHANDLED-EXCEPTION

			var jwt = jwtHandler.GenerateJwt(user, request.StoreId);

			//user.RecordLoginAction();

			await db.SaveChangesAsync(cancellationToken);

			return new SignInResult
			{
				AccessToken = jwt
			};
		}
	}
}
