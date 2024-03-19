using Marketplace.DTO.DTO.Subcategory;

namespace Marketplace.DTO.Services.Subcategory
{
	public interface ISubcategoryService
	{
		public bool CreateSubategory(SubcategoryDTO subcategoryDTO);

		public bool UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO);

		public List<SubcategoryDTO> GetSubcategories(int categoryId);
	}
}
