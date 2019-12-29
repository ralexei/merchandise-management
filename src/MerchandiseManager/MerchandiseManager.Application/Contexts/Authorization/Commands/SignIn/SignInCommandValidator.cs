using FluentValidation;
using MerchandiseManager.Application.Interfaces.Persistance;
using MerchandiseManager.Application.Interfaces.Validation.Persistence;
using MerchandiseManager.Core.Constants.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Authorization.Commands.SignIn
{
	public class SignInCommandValidator : AbstractValidator<SignInCommand>
	{
		private readonly IUserPersistenceValidator userPersistenceValidator;

		public SignInCommandValidator(IUserPersistenceValidator userPersistenceValidator)
		{
			this.userPersistenceValidator = userPersistenceValidator;

			InitializeRules();
		}

		private void InitializeRules()
		{
			RuleFor(r => r.Username)
				.NotEmpty()
				.MaximumLength(UserConstants.MaxUsernameLength)
				.Must((field) => userPersistenceValidator.UserWithUsernameExists(field));

			RuleFor(r => r.Password)
				.NotEmpty()
				.MinimumLength(UserConstants.MinPasswordLength)
				.MaximumLength(UserConstants.MaxPasswordLength);
		}
	}
}
