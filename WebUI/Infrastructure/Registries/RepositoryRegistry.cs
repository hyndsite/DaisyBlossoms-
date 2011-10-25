using DTOS;
using NHibernateLayer;
using RepoInfrastructure;
using StructureMap.Configuration.DSL;

namespace WebUI.Infrastructure.Registries {
    public class RepositoryRegistry : Registry {
        public RepositoryRegistry() {

            For<IRepository<Product>>()
                .Use<Repository<Product>>();

            For<IRepository<Category>>()
                .Use<Repository<Category>>();
        }
    }
}