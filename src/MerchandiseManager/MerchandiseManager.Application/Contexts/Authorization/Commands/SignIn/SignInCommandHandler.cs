using MediatR;
using MerchandiseManager.Application.Interfaces.Authentication;
using MerchandiseManager.Application.Interfaces.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Authorization.Commands.SignIn
{
	public class SignInCommandHandler : IRequestHandler<SignInCommand, string>
	{
		private readonly IDbContext _db;
		private readonly IJwtHandler _jwtHandler;

		public SignInCommandHandler(IDbContext db, IJwtHandler jwtHandler)
		{
			_db = db;
			_jwtHandler = jwtHandler;
		}

		public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
		{
			var user = _db
				.Users
				.FirstOrDefault();

			if (!user.IsPasswordValid(request.Password))
				throw new Exception();
			
			var jwt = _jwtHandler.GenerateJwt(user);

			user.RecordLoginAction();

			await _db.SaveChangesAsync(cancellationToken);

			return jwt;
		}
	}
}
