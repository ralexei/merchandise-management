using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandiseManager.Application.Contexts.SoldProducts.Commands.SellProductsFromCart
{
	public class SellProductsFromCartCommandValidator : AbstractValidator<SellProductsFromCartCommand>
	{
		public SellProductsFromCartCommandValidator()
		{
			RuleFor(r => r.SoldProducts)
				.NotEmpty();
		}
	}
}
