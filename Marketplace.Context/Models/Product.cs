using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Context.Models
{
	public class Product
	{
		public Guid ProductId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public Guid SubcategoryId { get; set; }

		public bool AdultOnly { get; set; }

		public uint Count { get; set; }

		// relationships

		public Subcategory? Subcategory { get; set; }

		public ICollection<Specification>? Specifications { get; set; }
	}
}
