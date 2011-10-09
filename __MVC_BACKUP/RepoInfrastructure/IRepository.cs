
namespace RepoInfrastructure
{
	public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity:class
	{
		bool Add(TEntity entity);
		bool Update(TEntity entity);
		bool Delete(TEntity entity);
	}
}
