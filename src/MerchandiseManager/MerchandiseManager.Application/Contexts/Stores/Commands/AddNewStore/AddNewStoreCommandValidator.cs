using FluentValidation;
using MerchandiseManager.Core.Constants.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Stores.Commands.AddNewStore
{
	public class AddNewStoreCommandValidator : AbstractValidator<AddNewStoreCommand>
	{
		public AddNewStoreCommandValidator()
		{
			RuleFor(r => r.StoreName)
				.NotEmpty()
				.MaximumLength(StorageConstants.MaxStorageNameLength);
		}
	}
}
