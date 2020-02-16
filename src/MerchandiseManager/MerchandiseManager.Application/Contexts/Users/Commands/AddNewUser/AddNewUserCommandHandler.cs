using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Users.Commands.AddNewUser
{
	public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, Unit>
	{
		private readonly IDbContext context;
		private readonly IMapper mapper;

		public AddNewUserCommandHandler(
			IDbContext context,
			IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
		{
			var newUser = mapper.Map<User>(request);

			await context.Users.AddAsync(newUser.SetPassword(request.Password));
			await context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
