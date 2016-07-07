using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Handlers
{
    public class CррFilePathHandler : IFilePathHandler
    {
        private static object locker = new object();

        public void TransformFilePath(DirectoryInfo directory, FileInfo file, string initialFolder, string resultPath)
        {
            if (file.Extension == ".cpp")
            {
                string[] cutFilePath = new string[] { file.FullName.Substring(initialFolder.Length+1) + " /" };
                Console.WriteLine(cutFilePath[0]);
                lock (locker)
                {
                    File.AppendAllLines(resultPath, cutFilePath);
                }
            }
        }
    }
}
