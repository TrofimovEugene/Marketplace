using Marketplace.Context.EFCode;
using Marketplace.Context.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;

namespace Marketplace.Tests
{
	[TestClass]
	public class TestSubcategory
	{
		const string connection = "Server=(localdb)\\mssqllocaldb;Database=MarketplaceDB;Trusted_Connection=True;MultipleActiveResultSets=true";
		[TestMethod]
		public void TestMethod1()
		{
			using var context = CreateNewContext();

			var categoriesCount = context.Subcategories.Where(x => x.CategoryId == 1).Count();
			var category = context.Categories.Where(x => x.NameCategory.Equals("Детские товары")).FirstOrDefault();
			if (categoriesCount == 0 && category != null)
			{
				context.Subcategories.AddRange(new List<Subcategory>() 
				{
					new Subcategory()
					{
						NameSubcategory = "Игрушки",
						CategoryId = category.CategoryId
					},
					new Subcategory()
					{
						NameSubcategory = "Одежда",
						CategoryId = category.CategoryId
					},
					new Subcategory()
					{
						NameSubcategory = "Мебель",
						CategoryId = category.CategoryId
					}
				});
				context.SaveChanges();
			}
			categoriesCount = context.Subcategories.Where(x => x.CategoryId == 2).Count();
			category = context.Categories.Where(x => x.NameCategory.Equals("Одежда, обувь и аксессуары")).FirstOrDefault();
			if (categoriesCount == 0 && category != null)
			{
				context.Subcategories.AddRange(new List<Subcategory>()
				{
					new Subcategory()
					{
						NameSubcategory = "Обувь",
						CategoryId = category.CategoryId
					},
					new Subcategory()
					{
						NameSubcategory = "Одежда",
						CategoryId = category.CategoryId
					},
					new Subcategory()
					{
						NameSubcategory = "Аксессуары",
						CategoryId = category.CategoryId
					}
				});
				context.SaveChanges();
			}

			var categories = context.Subcategories.ToList();
			foreach (var cat in categories)
				Console.WriteLine($"Name: {cat.NameSubcategory}. Id: {cat.SubcategoryId}");
		}

		[TestMethod]
		public void AddCategory()
		{
			using var context = CreateNewContext();

			var categoriesCount = context.Categories.Count();
			Console.WriteLine(categoriesCount);
			if (categoriesCount == 0)
			{
				context.Categories.AddRange(new List<Category> { 
					new Category()
					{
						NameCategory = "Детские товары"
					}, 
					new Category()
					{
						NameCategory = "Одежда, обувь и аксессуары"
					}
				});
				context.SaveChanges();
			}
			else
			{
				var categories = context.Categories.ToList();
				foreach (var cat in categories)
					Console.WriteLine($"Name: {cat.NameCategory}. Id: {cat.CategoryId}");
			}

		}

		[TestMethod]
		public void RemoveCategory()
		{
			using var context = CreateNewContext();
			var categories = context.Categories.ToList();
			context.Categories.RemoveRange(categories);
			context.SaveChanges();
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