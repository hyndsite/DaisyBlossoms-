using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DTOS
{
	public class Product
	{
		[HiddenInput(DisplayValue = false)]
		public virtual int ProductId { get; set; }
		public virtual string Name { get; set; }
		//public virtual int CategoryId { get; set; }

		[DataType(DataType.MultilineText)]
		public virtual string Description { get; set; }
		public virtual decimal Price { get; set; }
		public virtual decimal SalePrice { get; set; }
		public virtual int StockAmt { get; set; }
		public virtual bool StockLevelWarning { get; set; }
		public virtual string Dimensions { get; set; }
		public virtual bool PriceIncludesTax { get; set; }
		public virtual string TaxClass { get; set; }
		public virtual decimal ProductWeight { get; set; }
		public virtual decimal CubicWeight { get; set; }
		public virtual string PackageDimensions { get; set; }
		public virtual bool IncludeLatestProduct { get; set; }
		public virtual Category Category { get; set; }

		public Product()
		{
			Name = String.Empty;
			Description = String.Empty;
			Price = 0m;
			SalePrice = 0m;
			StockAmt = 0;
			StockLevelWarning = true;
			Dimensions = String.Empty;
			PriceIncludesTax = false;
			TaxClass = String.Empty;
			ProductWeight = 0;
			CubicWeight = 0;
			PackageDimensions = String.Empty;
			IncludeLatestProduct = false;
		}
	}
}
