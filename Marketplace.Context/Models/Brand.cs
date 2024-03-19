using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Context.Models
{
	public class Brand
	{
		public Guid BrandId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		// relationships

		public ICollection<Product>? Products { get; set; }
	}
}
