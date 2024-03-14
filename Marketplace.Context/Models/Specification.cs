using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Context.Models
{
	public class Specification
	{
		public Guid SpecificationId { get; set; }

		public string SpecificationName { get; set; }

		public string SpecificationDescription { get; set; }

		public Guid ProductId { get; set; }
	}
}
