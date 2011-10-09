using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOS
{
	public class Category
	{
		public virtual int CategoryId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual IList<Product> Products { get; set; }

		public Category()
		{
			Name = string.Empty;
			Description = string.Empty;
		}
	}
}
