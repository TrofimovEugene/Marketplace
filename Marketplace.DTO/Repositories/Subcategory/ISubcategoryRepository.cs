using Marketplace.DTO.DTO.Subcategory;

namespace Marketplace.DTO.Repositories.Subcategory
{
	public interface ISubcategoryRepository
	{
		public bool CreateSubategory(SubcategoryDTO subcategoryDTO);

		public bool UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO);

		public List<SubcategoryDTO> GetSubcategories(int categoryId);

		public bool CheckExistsSubcategory(Guid subcategoryId);
	}
}
