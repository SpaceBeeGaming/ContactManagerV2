using Autofac;
using ContactManagerLibrary.Models;
using ContactManagerLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleUI
{
    internal static class Program
    {
        private static void Main()
        {
            IContainer container = ContainerConfig.Configure();

            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                IApplication app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
