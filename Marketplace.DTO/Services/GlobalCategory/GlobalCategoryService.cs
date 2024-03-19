using Marketplace.Context.EFCode;
using Marketplace.DTO.DTO.Category;
using Marketplace.DTO.DTO.GlobalCategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.DTO.Services.GlobalCategory
{
	public class GlobalCategoryService : IGlobalCategoryService
	{
		private readonly MarketplaceDbContext _marketplaceDbContext;
		public GlobalCategoryService(MarketplaceDbContext marketplaceDbContext) 
		{
			_marketplaceDbContext = marketplaceDbContext;
		}

		public List<GlobalCategoryDTO> GetGlobalCategories()
		{
			return _marketplaceDbContext.GlobalCategories.Select(gc => new GlobalCategoryDTO()
			{
				NameGlobalCategory = gc.NameGlobalCategory,
				AltName = gc.AltName,
				GlobalCategoryId = gc.GlobalCategoryId,
			}).ToList();
		}

		public List<GlobalCategoriesWithCategoriesDTO> GetGlobalCategoriesWithCategories()
		{
			return _marketplaceDbContext.GlobalCategories.Include(x => x.Categories).Select(x => new GlobalCategoriesWithCategoriesDTO()
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
