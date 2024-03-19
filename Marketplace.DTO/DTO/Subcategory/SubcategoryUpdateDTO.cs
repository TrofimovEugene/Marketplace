namespace Marketplace.DTO.DTO.Subcategory
{
	public class SubcategoryUpdateDTO
	{
		public Guid SubcategoryId { get; set; }

		public string NameSubcategory { get; set; }

		public int CategoryId { get; set; }

		public string? AltName { get; set; }
	}
}
