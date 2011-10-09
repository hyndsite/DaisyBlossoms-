using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DTOS;

namespace NHibernateLayer
{
	public class ProductMap : ClassMap<Product>
	{
		public ProductMap()
		{
			Table("Products");
			Id(x => x.ProductId);
			Map(x => x.Name);
			//Map(x => x.CategoryId);
			Map(x => x.Description);
			Map(x => x.Price);
			Map(x => x.SalePrice);
			Map(x => x.StockAmt);
			Map(x => x.StockLevelWarning);
			Map(x => x.Dimensions);
			Map(x => x.PriceIncludesTax);
			Map(x => x.TaxClass);
			Map(x => x.ProductWeight);
			Map(x => x.CubicWeight);
			Map(x => x.PackageDimensions);
			Map(x => x.IncludeLatestProduct);
			References(x => x.Category).Column("CategoryId");
		}
	}
}
