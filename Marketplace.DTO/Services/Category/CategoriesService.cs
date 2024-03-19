using Marketplace.Context.EFCode;
using Marketplace.DTO.DTO.Category;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.DTO.Services.Category
{
	public class CategoriesService : ICategoriesService
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

        public List<CategoriesWithSubcategoriesDTO> GetCategoriesWithSubcategory(int globalCategoryId)
        {
            return _context.Categories
                .Where(x => x.GlobalCategoryId == globalCategoryId)
                .Include(x => x.Subcategories)
                .Select(cat => new CategoriesWithSubcategoriesDTO
            {
                NameCategory = cat.NameCategory,
                AltName = cat.AltName,
                Subcategories = cat.Subcategories.Select(subcat => new SubcategoryWithCategoryDTO
                {
                    NameSubcategory = subcat.NameSubcategory,
                    AltName = subcat.AltName,
                }).ToList()
            }).ToList();
        }

		public List<CategoryDTO> GetCategories(int globalCategoryId)
		{
			return _context.Categories
                .Where(x => x.GlobalCategoryId == globalCategoryId)
                .Select(cat => new CategoryDTO 
            { 
                NameCategory = cat.NameCategory,
                AltName = cat.AltName,
                GlobalCategoryId = cat.GlobalCategoryId,
            }).ToList();
		}
	}
}
