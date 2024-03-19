using Marketplace.DTO.DTO.GlobalCategory;

namespace Marketplace.DTO.Services.GlobalCategory
{
	public interface IGlobalCategoryService
	{
		public List<GlobalCategoryDTO> GetGlobalCategories();

		public List<GlobalCategoriesWithCategoriesDTO> GetGlobalCategoriesWithCategories();
	}
}
