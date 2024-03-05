using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Context.Models
{
	public class Category
	{
		public int CategoryId { get; set; }

		public string NameCategory { get; set; }

		public ICollection<Subcategory> Subcategories { get; set; }
	}
}
