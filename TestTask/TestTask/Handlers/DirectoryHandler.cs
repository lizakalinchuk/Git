using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Handlers
{
    public class DirectoryHandler : IDirectoryHandler
    {
        private readonly IFilePathHandler handler;
        private readonly string resultPath;
        private readonly string initialFolder;

        public DirectoryHandler(IFilePathHandler handler, string initialFolder, string resultPath = @"D:\results.txt")
        {
            this.handler = handler;
            this.resultPath = resultPath;
            this.initialFolder = initialFolder;
        }

        public void Handler(DirectoryInfo parentDirectory)
        {
            Task task = DirectoryHandle(parentDirectory);
            task.Wait();
        }

        private async Task DirectoryHandle(DirectoryInfo parentDirectory)
        {
            Task task = TransformFilePath(parentDirectory);
            foreach (DirectoryInfo directory in parentDirectory.GetDirectories())
            {
                await DirectoryHandle(directory);
            }

            await task;
        }

        private async Task TransformFilePath(DirectoryInfo directory)
        {
            await Task.Run(() =>
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                     this.handler.TransformFilePath(directory, file, this.initialFolder, this.resultPath);
                }
            });
        }
    }
}
