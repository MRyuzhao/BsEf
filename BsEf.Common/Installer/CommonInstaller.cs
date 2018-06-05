using BsEf.Common.TimeProvider;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BsEf.Common.Installer
{
    public class CommonInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ICurrentTimeProvider>().ImplementedBy<CurrentTimeProvider>().LifestyleSingleton()
            );
        }
    }
}