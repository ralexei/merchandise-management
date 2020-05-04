using FluentValidation;
using MerchandiseManager.Core.Constants.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Warehouses.Commands.AddNewStorage
{
	public class AddNewWarehouseCommandValidator : AbstractValidator<AddNewWarehouseCommand>
	{
		public AddNewWarehouseCommandValidator()
		{
			RuleFor(r => r.Name)
				.NotEmpty()
				.MaximumLength(StorageConstants.MaxStorageNameLength);

			RuleFor(r => r.Description)
				.NotEmpty()
				.MaximumLength(StorageConstants.MaxStorageDescriptionLength);
		}
	}
}
