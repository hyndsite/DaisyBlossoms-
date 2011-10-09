using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DTOS;
using RepoInfrastructure;
using Moq;
using System.Linq;

namespace UnitTests.Helpers {
	public static class Helper {
		public static IRepository<Product> GetProductRepository(List<Product> prods) {
			var prodRepo = new Mock<IRepository<Product>>();
			prodRepo.Setup(x => x.All()).Returns(prods.AsQueryable);
			prodRepo.Setup(x => x.FilterBy((It.IsAny<Expression<Func<Product, bool>>>()))).Returns(
				(Expression<Func<Product, bool>> filter) => prodRepo.Object.All().Where(filter));
			prodRepo.Setup(x => x.FindBy(It.IsAny<Expression<Func<Product, bool>>>())).Returns(
				(Expression<Func<Product, bool>> filter) => prodRepo.Object.FilterBy(filter).Single());
			return prodRepo.Object;
		}

		public static IRepository<Category> GetCategoryRepository(List<Category> categories) {
			var catRepo = new Mock<IRepository<Category>>();
			catRepo.Setup(x => x.All()).Returns(categories.AsQueryable);
			catRepo.Setup(x => x.FilterBy((It.IsAny<Expression<Func<Category, bool>>>()))).Returns(
				(Expression<Func<Category, bool>> filter) => catRepo.Object.All().Where(filter));
			catRepo.Setup(x => x.FindBy(It.IsAny<Expression<Func<Category, bool>>>())).Returns(
				(Expression<Func<Category, bool>> filter) => catRepo.Object.FilterBy(filter).Single());
			return catRepo.Object;
		}


		public static List<Product> GetProducts() {
			return new List<Product> {
			                         	new Product {
														ProductId = 1,
			                         	            	Name = "Red Rose Arrangement",
			                         	            	Description = "12 Red Roses",
														Category = new Category {
														                        	CategoryId = 1
														                        }

			                         	            },
			                         	new Product {
														ProductId = 2,
			                         	            	Name = "Lily Wreath",
			                         	            	Description = "10\" Pink Lily Wreath",
														Category = new Category {
														                        	CategoryId = 2
														                        }

			                         	            },
										new Product {
														ProductId = 3,
										            	Name = "Yellow Daisies Arrangement",
														Description = "Yellow Daisies with white Baby's Breath",
														Category = new Category {
														                        	CategoryId = 1
														                        }

										            }

			                         };
		}

		public static List<Category> GetCategories() {
			return new List<Category> {
			                          	new Category {
			                          	             	CategoryId = 1,
			                          	             	Description = "Different Arrangements",
			                          	             	Products = GetProducts().Where(x => x.Category.CategoryId == 1).ToList()
			                          	             },
			                          	new Category {

			                          	             	CategoryId = 2,
			                          	             	Name = "Wreaths",
			                          	             	Description = "Different Wreaths",
			                          	             	Products = GetProducts().Where(x => x.Category.CategoryId== 2).ToList()
			                          	             }
			                          };
		}
	}
}



	