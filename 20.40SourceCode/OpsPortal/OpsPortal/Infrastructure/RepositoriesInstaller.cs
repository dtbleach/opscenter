using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OpsPortal.Core;
using OpsPortal.Repositories;

namespace OpsPortal.Infrastructure
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Component.For<IUnitOfWork>()
                 .ImplementedBy<OpsPortalUnitOfWork>()
                 .LifestylePerWebRequest());

            container.Register(Component.For<IDatabaseFactory>()
                .ImplementedBy<OpsPortalDatabaseFactory>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IReleasePlanRepository>()
               .ImplementedBy<ReleasePlanRepository>()
               .LifestyleTransient());

            container.Register(Component.For<IReleaseJobRepository>()
              .ImplementedBy<ReleaseJobRepository>()
              .LifestyleTransient());

            container.Register(Component.For<IJenkinsJobRepository>()
                .ImplementedBy<JenkinsJobRepository>()
                .LifestylePerWebRequest());
        }
    }
}