using NHibernate;
using Ninject;
using Ninject.Activation;
using NHibernateLayer;
using RepoInfrastructure;

namespace WebUI.Infrastructure
{
	public class SessionProvider : Provider<ISession>
	{
		protected override ISession CreateInstance(IContext context)
		{
			UnitOfWork unitOfWork = (UnitOfWork)context.Kernel.Get<IUnitOfWork>();
			return unitOfWork.Session;
		}
	}
		
}