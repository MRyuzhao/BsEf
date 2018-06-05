using BsEf.Repository.UnitOfWork;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Data;

namespace BsEf.Repository.Installer
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<IDbContextProvider>()
                .Where(x => x.Name.EndsWith("Repository"))
                .WithService.DefaultInterfaces()
                .LifestylePerWebRequest());
            container.Register(Component.For<IDbContextProvider>().ImplementedBy<DbContextProvider>().LifestylePerWebRequest());
            container.Register(Component.For<BsEfDbContext>().LifestylePerWebRequest());
            container.Register(Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifestylePerWebRequest());
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<EntityFrameworkUnitOfWork>().LifestylePerWebRequest());
        }
    }
}