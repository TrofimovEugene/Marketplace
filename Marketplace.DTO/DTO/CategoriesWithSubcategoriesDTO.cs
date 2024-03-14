namespace Marketplace.DTO.DTO
{
	public class CategoriesWithSubcategoriesDTO
	{
		public string NameCategory { get; set; }

		public ICollection<SubcategoryDTO>? Subcategories { get; set; }
	}
}
