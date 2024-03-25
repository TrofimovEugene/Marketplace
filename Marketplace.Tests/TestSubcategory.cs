using Marketplace.Context.EFCode;
using Marketplace.DTO.DTO.Subcategory;
using Marketplace.DTO.Repositories.Subcategory;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;

namespace Marketplace.Tests
{
	[TestClass]
	public class TestSubcategory
	{
		const string connection = "Server=(localdb)\\mssqllocaldb;Database=MarketplaceDB;Trusted_Connection=True;MultipleActiveResultSets=true";
		MarketplaceDbContext dbContext;
		ISubcategoryRepository subcategoryService;

		public TestSubcategory()
		{
			dbContext = CreateNewContext();
			subcategoryService = new SubcategoryRepository(dbContext);
		}

		[TestMethod]
		public void GetSubcategories()
		{
			var subcategories = subcategoryService.GetSubcategories(6);
			Assert.IsNotNull(subcategories);
			if (subcategories.Count > 0) 
			{
				foreach (var subcategory in subcategories)
					Console.WriteLine($"Подкатегория: {subcategory.NameSubcategory}. Категории Id: {subcategory.CategoryId}");
			}
		}

		[TestMethod]
		public void AddSubcategories()
		{
			List<SubcategoryDTO> subcategoryDTOs = new List<SubcategoryDTO>() 
			{
				new SubcategoryDTO()
				{
					NameSubcategory = "Смартфоны",
					CategoryId = 6
				},
				new SubcategoryDTO()
				{
					NameSubcategory = "Аксессуары для смартфонов и телефонов",
					CategoryId = 6
				},
				new SubcategoryDTO()
				{
					NameSubcategory = "Смарт-часы",
					CategoryId = 6
				},
				new SubcategoryDTO()
				{
					NameSubcategory = "Фитнес-браслеты",
					CategoryId = 6
				},
				new SubcategoryDTO()
				{
					NameSubcategory = "Ремешки для смарт-часов и фитнес-браслетов",
					CategoryId = 6
				},
				new SubcategoryDTO()
				{
					NameSubcategory = "Аксессуары для смарт-часов и фитнес-браслетов",
					CategoryId = 6
				},
				new SubcategoryDTO()
				{
					NameSubcategory = "Мобильные телефоны",
					CategoryId = 6
				},
				new SubcategoryDTO()
				{
					NameSubcategory = "SIM-карты",
					CategoryId = 6
				},
				new SubcategoryDTO()
				{
					NameSubcategory = "Запчасти",
					CategoryId = 6
				},
				new SubcategoryDTO()
				{
					NameSubcategory = "Проводные и радиотелефоны",
					CategoryId = 6
				}
			};

			foreach (SubcategoryDTO subcategory in subcategoryDTOs)
			{
				subcategoryService.CreateSubategory(subcategory);
			}
		}

		public MarketplaceDbContext CreateNewContext()
		{
			var optionsBuilder = new DbContextOptionsBuilder<MarketplaceDbContext>();

			optionsBuilder.UseSqlServer(connection);
			var options = optionsBuilder.Options;

			return new MarketplaceDbContext(options);
		}
	}
}