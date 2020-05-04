using FluentValidation;
using MediatR;
using MerchandiseManager.Application.Interfaces.Validation.Persistence;
using MerchandiseManager.Core.Constants.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Products.Commands.EditProduct
{
	public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
	{
		public EditProductCommandValidator(ICategoryPersistenceValidator categoryPersistence)
		{
			RuleFor(r => r.CategoryId)
				.NotNull()
				.NotEqual(default(Guid))
				.Must((m) => categoryPersistence.CategoryWithIdExists(m.Value));

			RuleFor(r => r.ProductName)
				.NotEmpty()
				.MaximumLength(ProductConstants.MaxProductNameLength);

			RuleFor(r => r.ProductDescription)
				.MaximumLength(ProductConstants.MaxProductDescriptionLength);
		}
	}
}
