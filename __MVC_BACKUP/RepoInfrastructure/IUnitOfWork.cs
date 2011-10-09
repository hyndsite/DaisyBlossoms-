using System;
using NHibernate;

namespace RepoInfrastructure
{
	public interface IUnitOfWork : IDisposable
	{
		ISession Session { get; }
		void Commit();
		void Rollback();
	}
}
