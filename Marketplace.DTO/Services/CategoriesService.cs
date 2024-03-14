using Marketplace.Context.EFCode;
using Marketplace.DTO.DTO;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.DTO.Services
{
	public class CategoriesService
	{
		private readonly MarketplaceDbContext _context;
		public CategoriesService(MarketplaceDbContext context) 
		{
			_context = context;
		}

		public bool CreateCategory(CategoryDTO categoryDTO)
		{
			_context.Categories.Add(new Context.Models.Category
			{
				NameCategory = categoryDTO.NameCategory
			});
			var count = _context.SaveChangesAsync().Result;

			if (count > 0) 
				return true;
			else
				return false;
		}

		public bool CreateSubategory(SubcategoryDTO subcategoryDTO)
		{
			_context.Subcategories.Add(new Context.Models.Subcategory
			{
				NameSubcategory = subcategoryDTO.NameSubcategory,
				CategoryId = subcategoryDTO.CategoryId
			});
			var count = _context.SaveChangesAsync().Result;

			if (count > 0)
				return true;
			else
				return false;
		}

		public List<CategoriesWithSubcategoriesDTO> GetCategoriesWithSubcategory()
		{
			var result = new List<CategoriesWithSubcategoriesDTO>();
			var categories = _context.Categories.Include(cat => cat.Subcategories).ToList();

			foreach (var category in categories)
			{
				var categoriesWithSubcategoriesDTO = new CategoriesWithSubcategoriesDTO
				{
					NameCategory = category.NameCategory,
					Subcategories = new List<SubcategoryDTO>()
				};

				foreach (var subcategory in category.Subcategories)
				{
					categoriesWithSubcategoriesDTO.Subcategories.Add(new SubcategoryDTO
					{
						NameSubcategory = subcategory.NameSubcategory
					});
				}

				result.Add(categoriesWithSubcategoriesDTO);
			}

			return result;
		}

		public List<SubcategoryDTO> GetSubcategories()
		{
			return _context.Subcategories.Select(
				subcat => new SubcategoryDTO 
				{ 
					NameSubcategory = subcat.NameSubcategory 
				}).ToList();
		}
	}
}
