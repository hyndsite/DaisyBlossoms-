using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;
using RepoInfrastructure;
using NHibernate;


namespace NHibernateLayer {
	public class Repository<T> : IRepository<T> where T : class {
		private readonly ISession _session;

		public Repository(ISession session) {
			_session = session;
		}

		#region IReadOnlyRepository Members

		public IQueryable<T> All() {
			return _session.Query<T>();
		}

		public T FindBy(Expression<Func<T, bool>> expression) {
			return FilterBy(expression).Single();
		}

		public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression) {
			return All().Where(expression).AsQueryable();
		}
		#endregion

		#region IRepository Members

		public bool Add(T entity) {
			_session.Save(entity);
			return true;
		}

		public bool Update(T entity) {
			throw new NotImplementedException();
		}

		public bool Delete(T entity) {
			_session.Delete(entity);
			return _session.Contains(entity);
		}

		#endregion

	}
}
