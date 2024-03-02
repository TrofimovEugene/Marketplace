using Marketplace.Context.EFCode;
using Marketplace.Context.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Tests
{
	[TestClass]
	public class TestProduct
	{
		[TestMethod]
		public void TestMethod1()
		{
			var connection = "Server=(localdb)\\mssqllocaldb;Database=MarketplaceDB;Trusted_Connection=True;MultipleActiveResultSets=true";

			var optionsBuilder = new DbContextOptionsBuilder<MarketplaceDbContext>();

			optionsBuilder.UseSqlServer(connection);
			var options = optionsBuilder.Options;

			using var context = new MarketplaceDbContext(options);
			var productCount = context.Products.Count();
			Console.WriteLine($"Product count: {productCount}");

			if (productCount > 0)
			{
				var products = context.Products
					.Include(product => product.Category)
					.ToList();
				foreach (var product in products)
				{
					Console.WriteLine($"Name: {product.Name}. Id: {product.ProductId}");
					Console.WriteLine($"Category Name: {product.Category.NameCategory}. CategoryId: {product.Category.CategoryId}.");
					Console.WriteLine();
				}
			}
			else
			{
				List<Product> products = new List<Product>
				{
					new Product {
						Name = "Teddy Bear",
						Category = context.Categories.Where(x => x.NameCategory.Equals("Toys")).FirstOrDefault(),
						Price = 150.00M,
						Description = "It's Teddy Bear!!!"
					},
					new Product {
						Name = "Car",
						Category = context.Categories.Where(x => x.NameCategory.Equals("Toys")).FirstOrDefault(),
						Price = 250.00M,
						Description = "It's Audi A5 Coupe!!!"
					},
					new Product {
						Name = "Jacket",
						Category = context.Categories.Where(x => x.NameCategory.Equals("Clothes")).FirstOrDefault(),
						Price = 100.00M,
						Description = "Jacket"
					},
					new Product {
						Name = "T-Short",
						Category = context.Categories.Where(x => x.NameCategory.Equals("Clothes")).FirstOrDefault(),
						Price = 350.00M,
						Description = "T-Short"
					}
				};

				context.Products.AddRange(products);
				context.SaveChanges();
			}
		}
	}
}
