using Marketplace.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Context.EFCode
{
	public class MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : DbContext(options)
	{
		public DbSet<Product> Products { get; set; }

		public DbSet<Subcategory> Subcategories { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Specification> Specifications { get; set; }
	}
}
