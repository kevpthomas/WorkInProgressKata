using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using WipKata.Core.Interfaces;

namespace WipKata.Runner
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.Clear();

            var builder = new ContainerBuilder();

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(path, "WipKata.Infrastructure.dll"));
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(allAssemblies).AsImplementedInterfaces();

            var container = builder.Build();

            // https://autofaccn.readthedocs.io/en/latest/getting-started/index.html#application-execution
            using (var scope = container.BeginLifetimeScope())
            {
                var cardProcessor = scope.Resolve<ICardProcessor>();
                cardProcessor.RunAllSequences();
            }

            Console.Read();
        }
    }
}
