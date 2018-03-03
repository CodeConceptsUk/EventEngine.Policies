using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EventEngine.Interfaces;
using EventEngine.Interfaces.Commands;
using EventEngine.Policies.Application.Commands;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;

namespace EventEngine.Policies.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Install(new EventEngineInstaller(), new PoliciesInstaller(), new LocalInstaller());

            var commandDispatcher = container.Resolve<ICommandDispatcher>();
            var createNewPolicyCommand = new CreateNewPolicyCommand
            {
                CustomerId = "A1",
                PolicyNumber = "P1"
            };
            commandDispatcher.Dispatch(createNewPolicyCommand);
        }
    }


    public class PoliciesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(typeof(Policy).Assembly.FullName)
                .Where(t => t.GetInterfaces().Any())
                .WithService.AllInterfaces().LifestyleTransient());
        }
    }


    public class LocalInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(GetType().Assembly.FullName)
                .Where(t => t.GetInterfaces().Any())
                .WithService.AllInterfaces().LifestyleTransient());
        }
    }

    public class EventEngineInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(typeof(IView).Assembly.FullName)
                .Where(t => t.GetInterfaces().Any())
                .WithService.AllInterfaces().LifestyleTransient());
        }
    }
}
