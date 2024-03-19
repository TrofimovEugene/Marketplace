using Marketplace.Context.EFCode;
using Marketplace.DTO.Services.GlobalCategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Marketplace.Tests
{
	[TestClass]
	public class TestGlobalCategory
	{
		const string connection = "Server=(localdb)\\mssqllocaldb;Database=MarketplaceDB;Trusted_Connection=True;MultipleActiveResultSets=true";
		MarketplaceDbContext dbContext;
		IGlobalCategoryService globalCategoryService;

		public TestGlobalCategory()
		{
			dbContext = CreateNewContext();
			globalCategoryService = new GlobalCategoryService(dbContext);
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
