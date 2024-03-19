using Marketplace.DTO.DTO.Category;

namespace Marketplace.DTO.DTO.GlobalCategory
{
	public class GlobalCategoriesWithCategoriesDTO
	{
		public string NameGlobalCategory { get; set; }

		public string? AltName { get; set; }

		public ICollection<CategoryDTO>? Categories { get; set; }
	}
}
