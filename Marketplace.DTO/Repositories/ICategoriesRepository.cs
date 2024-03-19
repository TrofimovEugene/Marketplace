using Marketplace.DTO.DTO.Category;
using Marketplace.DTO.DTO.GlobalCategory;
using Marketplace.DTO.DTO.Subcategory;

namespace Marketplace.DTO.Repositories
{
	public interface ICategoriesRepository
	{
		public List<GlobalCategoryDTO> GetGlobalCategories();

		public List<GlobalCategoriesWithCategoriesDTO> GetGlobalCategoriesWithCategories();

		public List<CategoryDTO> GetCategories(int globalCategoryId);

		public List<CategoriesWithSubcategoriesDTO> GetCategoriesWithSubcategories(int globalCategoryId);

		public List<SubcategoryDTO> GetSubcategories(int category);

		public bool CreateCategory(CategoryDTO categoryDTO);

		public bool UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);

		public bool CreateSubcategory(SubcategoryDTO subcategoryDTO);

		public bool UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO);
	}
}
