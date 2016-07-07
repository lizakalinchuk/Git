using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DI;
using TestTask.Handlers;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            if (ArgumentVerificator.VerifyArgsCount(args) && ArgumentVerificator.VerifyExistanceInitDir(args))
            {
                try
                {
                    var filePathHandler = Dependency.ResolveFilePathHandler(args[1]);
                    var directoryHandler = args.Length >= 3 && ArgumentVerificator.VerifyExistenceResultFile(args)
                        ? Dependency.ResolveDirectoryHandler(filePathHandler, args[0], args[2])
                        : Dependency.ResolveDirectoryHandler(filePathHandler, args[0]);
                    directoryHandler.Handler(new DirectoryInfo(args[0]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
