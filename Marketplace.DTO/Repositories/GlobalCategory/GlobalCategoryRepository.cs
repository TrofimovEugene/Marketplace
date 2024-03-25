using Marketplace.Context.EFCode;
using Marketplace.DTO.DTO.Category;
using Marketplace.DTO.DTO.GlobalCategory;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.DTO.Repositories.GlobalCategory
{
	public class GlobalCategoryRepository : IGlobalCategoryRepository
	{
		private readonly MarketplaceDbContext _marketplaceDbContext;
		public GlobalCategoryRepository(MarketplaceDbContext marketplaceDbContext) 
		{
			_marketplaceDbContext = marketplaceDbContext;
		}

		public bool CheckExistsGlobalCategory(int globalCategoryId)
		{
			return _marketplaceDbContext.GlobalCategories.Any(x => x.GlobalCategoryId == globalCategoryId);
		}

		public List<GlobalCategoryDTO> GetGlobalCategories()
		{
			return _marketplaceDbContext.GlobalCategories
				.AsNoTracking()
				.Select(gc => new GlobalCategoryDTO()
			{
				NameGlobalCategory = gc.NameGlobalCategory,
				AltName = gc.AltName,
				GlobalCategoryId = gc.GlobalCategoryId,
			}).ToList();
		}

		public List<GlobalCategoriesWithCategoriesDTO> GetGlobalCategoriesWithCategories()
		{
			return _marketplaceDbContext.GlobalCategories
				.AsNoTracking()
				.Include(x => x.Categories)
				.Select(x => new GlobalCategoriesWithCategoriesDTO()
			{
				NameGlobalCategory = x.NameGlobalCategory,
				AltName = x.AltName,
				Categories = x.Categories.Select(cat => new CategoryDTO()
				{
					NameCategory = cat.NameCategory,
					AltName = cat.AltName,
					GlobalCategoryId = cat.GlobalCategoryId
				}).ToList()
			}).ToList();
		}
	}
}
