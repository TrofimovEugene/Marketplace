using Marketplace.DTO.DTO.Subcategory;

namespace Marketplace.DTO.DTO.Category
{
    public class CategoriesWithSubcategoriesDTO
    {
        public string NameCategory { get; set; }

        public string? AltName { get; set; }

        public ICollection<SubcategoryWithCategoryDTO>? Subcategories { get; set; }
    }

    public class SubcategoryWithCategoryDTO
    {
		public string NameSubcategory { get; set; }

        public string? AltName { get; set; }
	}
}
