using Autofac;
using ContactManagerLibrary;
using ContactManagerLibrary.Utilities;
using System.Linq;
using System.Reflection;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //ConsoleUI
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ConsoleEmailer>().As<IConsoleEmailer>();

            //ContactManagerLibrary
            builder.RegisterType<ContactHandler>().As<IContactHandler>();
            //Utilities
            builder.RegisterType<SimDataAccess>().As<IDataAccess>();
            builder.RegisterType<SimEmailer>().As<IEmailer>();




            return builder.Build();
        }
    }
}
