using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Handlers;

namespace TestTask.DI
{
    public class Dependency
    {
        const string ALL = "all";
        const string CPP = "cpp";
        const string REVERSED1 = "reversed1";
        const string REVERSED2 = "reversed2";

        public static IFilePathHandler ResolveFilePathHandler(string action)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AllFilePathHandler>().Named<IFilePathHandler>("AllHandler");
            builder.RegisterType<Reversed1FilePathHandler>().Named<IFilePathHandler>("Reversed1Handler");
            builder.RegisterType<Reversed2FilePathHandler>().Named<IFilePathHandler>("Reversed2Handler");
            builder.RegisterType<CррFilePathHandler>().Named<IFilePathHandler>("CppHandler");
            var container = builder.Build();

            switch (action.Trim().ToLower())
            {
                case ALL:
                    return (AllFilePathHandler)container.ResolveNamed<IFilePathHandler>("AllHandler");

                case CPP:
                    return (CррFilePathHandler)container.ResolveNamed<IFilePathHandler>("CppHandler");

                case REVERSED1:
                    return (Reversed1FilePathHandler)container.ResolveNamed<IFilePathHandler>("Reversed1Handler");

                case REVERSED2:
                    return (Reversed2FilePathHandler)container.ResolveNamed<IFilePathHandler>("Reversed2Handler");

                default:
                    throw new ArgumentException("Please enter correct action name (all, reversed1, reversed2, cpp)");
            }
        }

        public static DirectoryHandler ResolveDirectoryHandler(IFilePathHandler handler, string initialFolder, string resultPath = @"result.txt")
        {
            var builder = new ContainerBuilder();
            builder.Register(b => new DirectoryHandler(handler, initialFolder, resultPath)).As<IDirectoryHandler>();
            var container = builder.Build();
            return (DirectoryHandler)container.Resolve<IDirectoryHandler>();
        }
    }
}
