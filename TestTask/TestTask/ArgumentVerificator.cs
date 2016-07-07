using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public static class ArgumentVerificator
    {
        public static bool VerifyArgsCount(string[] args)
        {
            if (args.Length > 1)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Please enter parameters: initial folder and/or action name (all, reversed1, reversed2, cpp)");
                return false;
            }
        }

        public static bool VerifyExistanceInitDir(string[] args)
        {
            if (args.Length > 0)
            {
                var directory = new DirectoryInfo(args[0]);
                if (!directory.Exists)
                {
                    Console.WriteLine("Please enter correct directory");
                    return false;
                }
                return true;
            }
            return false;
        }

        public static bool VerifyExistenceResultFile(string[] args)
        {
            if (args.Length > 2)
            {
                var file = new FileInfo(args[2]);
                if (!file.Exists)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
