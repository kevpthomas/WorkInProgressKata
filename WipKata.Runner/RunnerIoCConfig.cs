using IoC;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
// ReSharper disable StringLiteralTypo

namespace WipKata.Runner
{
    public class RunnerIoCConfig : IoCConfig
    {
        private readonly Lazy<Assembly[]> _iocAssemblies = new Lazy<Assembly[]>(() =>
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(path, "WipKata.Infrastructure.dll"));
            return AppDomain.CurrentDomain.GetAssemblies();
        });

        protected override Assembly[] IocAssemblies => _iocAssemblies.Value;

        public static RunnerIoCConfig Instance { get; } = new RunnerIoCConfig();
    }
}