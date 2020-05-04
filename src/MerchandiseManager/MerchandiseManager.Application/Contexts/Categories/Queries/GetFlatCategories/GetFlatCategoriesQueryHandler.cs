using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Categories.ViewModels;
using MerchandiseManager.Application.Helpers.Extensions.Linq;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Application.Models.Filtering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Categories.Queries.GetFlatCategories
{
	public class GetFlatCategoriesQueryHandler : IRequestHandler<GetFlatCategoriesQuery, FilteredResult<CategoryFlatViewModel>>
	{
		private readonly IDbContext db;
		private readonly IMapper mapper;

		public GetFlatCategoriesQueryHandler(IDbContext db, IMapper mapper)
		{
			this.db = db;
			this.mapper = mapper;
		}

		public Task<FilteredResult<CategoryFlatViewModel>> Handle(GetFlatCategoriesQuery request, CancellationToken cancellationToken)
		{
			var categories = db
				.Categories
				.Include(i => i.Children)
				.AsEnumerable()
				.Where(w => w.ParentId == null);

			var flattenedCategories = categories.ToList().Flatten(f => f.Children, (c, l) =>
			{
				c.NestingLevel = l;

				return c;
			}, f => mapper.Map<CategoryFlatViewModel>(f));
			var totalCategoriesCount = flattenedCategories.Count();

			return Task.FromResult(new FilteredResult<CategoryFlatViewModel>(flattenedCategories, totalCategoriesCount, flattenedCategories.Count()));
		}
	}
}
