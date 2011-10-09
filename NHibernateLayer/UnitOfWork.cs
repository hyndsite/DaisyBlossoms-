using System;
using System.Data;
using NHibernate;
using RepoInfrastructure;

namespace NHibernateLayer
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ISessionFactory _sessionFactory;
		private readonly ITransaction _transaction;
		public ISession Session { get; private set; }

		public UnitOfWork(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
			
			//Open Session
			Session = _sessionFactory.OpenSession();
			Session.FlushMode = FlushMode.Auto;
			_transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
		}

		public void Commit()
		{
			if (!_transaction.IsActive)
				throw new InvalidOperationException("There is no active Transaction");
			_transaction.Commit();
		}

		public void Rollback()
		{
			if (_transaction.IsActive)
				_transaction.Rollback();
		}
		
		//Close open session
		public void Dispose()
		{
			Session.Close();
		}
	}
}
