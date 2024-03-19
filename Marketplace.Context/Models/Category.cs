namespace Marketplace.Context.Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		public string NameCategory { get; set; }

		public string? AltName { get; set; }

		public int GlobalCategoryId { get; set; }

		public ICollection<Subcategory>? Subcategories { get; set; }
	}
}
