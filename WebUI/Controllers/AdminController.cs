using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DTOS;
using NHibernate;
using RepoInfrastructure;
using WebUI.Filters;
using WebUI.Models.Admin;


namespace WebUI.Controllers
{
    public class AdminController : Controller {
    	private IRepository<Product> _prodRepo;
    	private IRepository<Category> _catRepo;

		public AdminController() {}

		public AdminController(IRepository<Product> prodRepo, IRepository<Category> catRepo ) {
			_prodRepo = prodRepo;
			_catRepo = catRepo;
		}

		public ViewResult List() {
			return View(_prodRepo.All());
		}

		[HttpGet]
		public ViewResult Add() {
		    return View(new Product());
		}

       

        [HttpPost]
        [UnitOfWork]
		public ActionResult Add(Product product) {

			if (_prodRepo.Add(product)) {
				return RedirectToAction("List", "Admin");
			}
			return View("Add", product);
		}

		public ViewResult Edit(int id) {
			var productIDtoEdit = id;
			return View(_prodRepo.FindBy(prod => prod.ProductId == productIDtoEdit));
		}

        [UnitOfWork]
		public ViewResult Delete(int id) {
			var productIDtoEdit = id;
			var productToDelete = _prodRepo.FindBy(x => x.ProductId == productIDtoEdit);
			if (productToDelete != null) {
				if (_prodRepo.Delete(productToDelete)) {
					return View("List");
				}
			}
			return View("List");
		}

        protected override void OnActionExecuted(ActionExecutedContext filterContext) {
            base.OnActionExecuted(filterContext);
        }
    }
}
