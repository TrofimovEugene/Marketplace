using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Context.Models
{
	public class Subcategory
	{
		public Guid SubcategoryId { get; set; }

		public string NameSubcategory { get; set; }

		//
		public int CategoryId { get; set; }

		public ICollection<Product>? Products { get; set; }
	}
}
