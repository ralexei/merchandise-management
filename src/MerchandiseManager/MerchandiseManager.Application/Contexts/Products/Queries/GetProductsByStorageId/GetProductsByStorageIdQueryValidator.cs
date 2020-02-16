using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.Products.Queries.GetProductsByStorageId
{
	public class GetProductsByStorageIdQueryValidator : AbstractValidator<GetProductsByStorageIdQuery>
	{
		public GetProductsByStorageIdQueryValidator()
		{
			RuleFor(r => r.StorageId)
				.NotNull();
		}
	}
}
