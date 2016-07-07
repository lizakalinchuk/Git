using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Handlers
{
    public interface IDirectoryHandler
    {
        void Handler(DirectoryInfo parentDirectory);
    }
}
