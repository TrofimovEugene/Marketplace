using Marketplace.DTO.DTO.GlobalCategory;

namespace Marketplace.DTO.Repositories.GlobalCategory
{
	public interface IGlobalCategoryRepository
	{
		public List<GlobalCategoryDTO> GetGlobalCategories();

		public List<GlobalCategoriesWithCategoriesDTO> GetGlobalCategoriesWithCategories();

		public bool CheckExistsGlobalCategory(int globalCategoryId);
	}
}
