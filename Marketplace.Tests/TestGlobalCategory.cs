using Marketplace.Context.EFCode;
using Marketplace.DTO.Repositories.GlobalCategory;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Tests
{
	[TestClass]
	public class TestGlobalCategory
	{
		const string connection = "Server=(localdb)\\mssqllocaldb;Database=MarketplaceDB;Trusted_Connection=True;MultipleActiveResultSets=true";
		MarketplaceDbContext dbContext;
		IGlobalCategoryRepository globalCategoryService;

		public TestGlobalCategory()
		{
			dbContext = CreateNewContext();
			globalCategoryService = new GlobalCategoryRepository(dbContext);
		}

		[TestMethod]
		public void GetGlobalCategories()
		{
			var gc = globalCategoryService.GetGlobalCategories();
			foreach (var category in gc)
			{
				Console.WriteLine($"Название глобальной категории: {category.NameGlobalCategory}");
			}
		}

		[TestMethod]
		public void GetGlobalCategoriesWithCategories()
		{
			var gc = globalCategoryService.GetGlobalCategoriesWithCategories();
			foreach (var category in gc)
			{
				Console.WriteLine($"Название глобальной категории: {category.NameGlobalCategory}");
				Console.WriteLine();
				if (category.Categories != null)
				{
					foreach (var category2 in category.Categories)
					{
						Console.WriteLine($"Название категории: {category2.NameCategory}");
					}
				}
				Console.WriteLine();
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
