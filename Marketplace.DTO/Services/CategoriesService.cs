using Marketplace.Context.EFCode;
using Marketplace.DTO.DTO.Category;
using Marketplace.DTO.DTO.Subcategory;
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
				NameCategory = categoryDTO.NameCategory,
				AltName = categoryDTO.AltName,
				GlobalCategoryId = categoryDTO.GlobalCategoryId
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
				AltName = subcategoryDTO.AltName,
				CategoryId = subcategoryDTO.CategoryId
			});
			var count = _context.SaveChangesAsync().Result;

			if (count > 0)
				return true;
			else
				return false;
		}

		public bool UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
		{
			var category = _context.Categories.SingleOrDefault(x => x.CategoryId == categoryUpdateDTO.CategoryId);
			if (category != null)
			{
				category.NameCategory = categoryUpdateDTO.NameCategory;
				category.AltName = categoryUpdateDTO.AltName;
				category.GlobalCategoryId = categoryUpdateDTO.GlobalCategoryId;
				_context.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO)
		{
			var subcategory = _context.Subcategories.SingleOrDefault(
				x => x.SubcategoryId == subcategoryUpdateDTO.SubcategoryId);
			if (subcategory != null)
			{
				subcategory.NameSubcategory = subcategoryUpdateDTO.NameSubcategory;
				subcategory.AltName = subcategoryUpdateDTO.AltName;
				subcategory.CategoryId = subcategoryUpdateDTO.CategoryId;
				_context.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
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
					Subcategories = new List<SubcategoryWithCategoryDTO>()
				};

				if (category.Subcategories != null)
				{
					foreach (var subcategory in category.Subcategories)
					{
						categoriesWithSubcategoriesDTO.Subcategories.Add(new SubcategoryWithCategoryDTO
						{
							NameSubcategory = subcategory.NameSubcategory
						});
					}
				}

				result.Add(categoriesWithSubcategoriesDTO);
			}

			return result;
		}

		public List<SubcategoryDTO> GetSubcategories(int categoryId)
		{
			return _context.Subcategories.Where(x => x.CategoryId == categoryId).Select(
				subcat => new SubcategoryDTO 
				{ 
					NameSubcategory = subcat.NameSubcategory,
					AltName = subcat.AltName,
					CategoryId = subcat.CategoryId
				}).ToList();
		}
	}
}
