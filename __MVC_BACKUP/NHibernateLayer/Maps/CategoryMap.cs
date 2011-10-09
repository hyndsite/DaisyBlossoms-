using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTOS;
using FluentNHibernate.Mapping;

namespace NHibernateLayer
{
	public class CategoryMap : ClassMap<Category>
	{
		public CategoryMap()
		{
			Table("Categories");
			Id(x => x.CategoryId);
			Map(x => x.Name);
			Map(x => x.Description).Column("CategoryDescription");
			HasMany(x => x.Products).KeyColumn("ProductId");
		}
	}
}
