using Marketplace.Context.EFCode;
using Marketplace.Context.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;

namespace Marketplace.Tests
{
	[TestClass]
	public class TestCategory
	{
		[TestMethod]
		public void TestMethod1()
		{
			var connection = "Server=(localdb)\\mssqllocaldb;Database=MarketplaceDB;Trusted_Connection=True;MultipleActiveResultSets=true";

			var optionsBuilder = new DbContextOptionsBuilder<MarketplaceDbContext>();

			optionsBuilder.UseSqlServer(connection);
			var options = optionsBuilder.Options;

			using var context = new MarketplaceDbContext(options);

			var categoriesCount = context.Categories.Count();
			Console.WriteLine(categoriesCount);
			if (context.Categories.Where(x => x.NameCategory.Equals("Toys")) == null)
			{
				context.Categories.Add(new Category()
				{
					NameCategory = "Toys"
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
	}
}