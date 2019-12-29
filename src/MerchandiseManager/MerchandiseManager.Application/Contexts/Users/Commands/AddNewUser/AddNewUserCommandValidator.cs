using FluentValidation;
using MerchandiseManager.Application.Interfaces.Validation.Persistence;
using MerchandiseManager.Core.Constants.Validation;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Users.Commands.AddNewUser
{
	public class AddNewUserCommandValidator : AbstractValidator<AddNewUserCommand>
	{
		public AddNewUserCommandValidator(IUserPersistenceValidator userPersistenceValidator)
		{
			RuleFor(r => r.Username)
				.NotEmpty()
				.MaximumLength(UserConstants.MaxUsernameLength)
				.Must((u) => !userPersistenceValidator.UserWithUsernameExists(u));

			RuleFor(r => r.Password)
				.NotEmpty()
				.MinimumLength(UserConstants.MinPasswordLength)
				.MaximumLength(UserConstants.MaxFirstNameLength);
			
			RuleFor(r => r.FirstName)
				.MaximumLength(UserConstants.MaxFirstNameLength);

			RuleFor(r => r.LastName)
				.NotEmpty()
				.MaximumLength(UserConstants.MaxLastNameLength);
		}
	}
}
