using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOS;
using RepoInfrastructure;

namespace WebUI.Models.Admin
{
	public class ProductListViewModel
	{
		public IQueryable<Product> Products { get; set; }
		public IQueryable<Category> Categories { get; set; }
	}
}