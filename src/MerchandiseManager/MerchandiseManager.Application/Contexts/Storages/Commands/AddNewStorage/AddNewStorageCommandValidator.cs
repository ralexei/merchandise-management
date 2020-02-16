using FluentValidation;
using MerchandiseManager.Core.Constants.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Storages.Commands.AddNewStorage
{
	public class AddNewStorageCommandValidator : AbstractValidator<AddNewStorageCommand>
	{
		public AddNewStorageCommandValidator()
		{
			RuleFor(r => r.StorageName)
				.NotEmpty()
				.MaximumLength(StorageConstants.MaxStorageNameLength);

			RuleFor(r => r.StorageDescription)
				.NotEmpty()
				.MaximumLength(StorageConstants.MaxStorageDescriptionLength);
		}
	}
}
