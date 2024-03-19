namespace Marketplace.Context.Models
{
	public class Subcategory
	{
		public Guid SubcategoryId { get; set; }

		public string NameSubcategory { get; set; }

		public string? AltName { get; set; }

		//
		public int CategoryId { get; set; }

		public ICollection<Product>? Products { get; set; }
	}
}
