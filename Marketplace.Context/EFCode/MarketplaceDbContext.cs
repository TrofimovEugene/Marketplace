using Marketplace.Context.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Context.EFCode
{
	public class MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : DbContext(options)
	{
		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }
	}
}
