using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Context.Models
{
	public class GlobalCategory
	{
		public int GlobalCategoryId { get; set; }

		public string NameGlobalCategory { get; set; }

		public string? AltName { get; set; }

		public ICollection<Category>? Categories { get; set; }
	}
}
