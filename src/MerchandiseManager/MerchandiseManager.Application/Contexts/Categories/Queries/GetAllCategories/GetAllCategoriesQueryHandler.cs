using AutoMapper;
using MediatR;
using MerchandiseManager.Application.Contexts.Categories.ViewModels;
using MerchandiseManager.Application.Interfaces.Persistence;
using MerchandiseManager.Application.Models.Filtering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseManager.Application.Contexts.Categories.Queries.GetAllCategories
{
	public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, FilteredResult<CategoryViewModel>>
	{
		private readonly IDbContext context;
		private readonly IMapper mapper;

		public GetAllCategoriesQueryHandler(IDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<FilteredResult<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
		{
			var categories = context
				.Categories
				.Include(i => i.Children)
				.AsEnumerable()
				.Where(w => w.ParentId == null);

			var totalCategoriesCount = await context.Categories.CountAsync();
			var resultData = mapper.Map<IEnumerable<CategoryViewModel>>(categories.ToList());

			return new FilteredResult<CategoryViewModel>(resultData, totalCategoriesCount, resultData.Count());
		}
	}
}
