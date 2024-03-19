using Marketplace.Context.EFCode;
using Marketplace.DTO.DTO.Subcategory;

namespace Marketplace.DTO.Services.Subcategory
{
	public class SubcategoryService : ISubcategoryService
	{
		private readonly MarketplaceDbContext _marketplaceDbContext;

		public SubcategoryService(MarketplaceDbContext marketplaceDbContext)
		{
			_marketplaceDbContext = marketplaceDbContext;
		}

		public bool CreateSubategory(SubcategoryDTO subcategoryDTO)
		{
			_marketplaceDbContext.Subcategories.Add(new Context.Models.Subcategory
			{
				NameSubcategory = subcategoryDTO.NameSubcategory,
				AltName = subcategoryDTO.AltName,
				CategoryId = subcategoryDTO.CategoryId
			});
			var count = _marketplaceDbContext.SaveChangesAsync().Result;

			if (count > 0)
				return true;
			else
				return false;
		}

		public bool UpdateSubcategory(SubcategoryUpdateDTO subcategoryUpdateDTO)
		{
			var subcategory = _marketplaceDbContext.Subcategories.SingleOrDefault(
				x => x.SubcategoryId == subcategoryUpdateDTO.SubcategoryId);
			if (subcategory != null)
			{
				subcategory.NameSubcategory = subcategoryUpdateDTO.NameSubcategory;
				subcategory.AltName = subcategoryUpdateDTO.AltName;
				subcategory.CategoryId = subcategoryUpdateDTO.CategoryId;
				_marketplaceDbContext.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
		}

		public List<SubcategoryDTO> GetSubcategories(int categoryId)
		{
			return _marketplaceDbContext.Subcategories.Where(x => x.CategoryId == categoryId).Select(
				subcat => new SubcategoryDTO
				{
					NameSubcategory = subcat.NameSubcategory,
					AltName = subcat.AltName,
					CategoryId = subcat.CategoryId
				}).ToList();
		}
	}
}
