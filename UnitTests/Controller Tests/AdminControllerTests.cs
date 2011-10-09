using System.Linq;
using System.Web.Mvc;
using DTOS;
using NUnit.Framework;
using RepoInfrastructure;
using UnitTests.Helpers;
using WebUI.Controllers;
using System.Collections.Generic;

namespace UnitTests.Controller {
	
	[TestFixture]
	public class AdminControllerTests {
		private IRepository<Product> ProductRepo { get; set; }
		private IRepository<Category> CategoryRepo { get; set; }
		private AdminController AdminController { get; set; }
		//private List<Product> Products { get; set; }

		[SetUp]
		public void Setup() {
			ProductRepo = Helper.GetProductRepository(Helper.GetProducts());
			CategoryRepo = Helper.GetCategoryRepository(Helper.GetCategories());
			AdminController = new AdminController(ProductRepo, CategoryRepo);
		}


		[Test]
		public void Test_FakeRepository_Methods_Return_Correct_Results() {
			var allProds = ProductRepo.All();
			var catProds = ProductRepo.FilterBy(x => x.Category.CategoryId == 1);
			var singleProd = ProductRepo.FindBy(x => x.Name == "Red Rose Arrangement");

			Assert.AreEqual(3, allProds.Count());
			Assert.AreEqual(2, catProds.Count());
			Assert.AreEqual(1, singleProd.ProductId);
		}

		[Test]
		public void Test_FakeCategories_Methods_Return_Correct_Results() {
			var allCats = CategoryRepo.All();
			var singleCat = CategoryRepo.FilterBy(x => x.CategoryId == 1);
			
			Assert.AreEqual(2, allCats.Count());
			Assert.AreEqual(1, singleCat.Count());
		}

		[Test]
		public void Can_Load_A_Product_In_Edit_View() {
			var prod = ProductRepo.FindBy(x => x.ProductId == 1);
			var viewModel = AdminController.Edit(prod.ProductId);
			Assert.AreEqual(prod, viewModel.ViewData.Model);
		}

		[Test]
		public void Can_Add_A_New_Product() {
			
		}

		//[Test]
		//public void Can_Delete_A_Product_From_List() {
		//    var prodToDelete = ProductRepo.FindBy(x => x.ProductId == 2);
		//    var viewModel = AdminController.Delete(prodToDelete.ProductId);
		//    var products = ProductRepo.All();
		//    Assert.AreEqual(products, viewModel.ViewData.Model);
		//    Assert.AreEqual(2, );

		//}
	}
}