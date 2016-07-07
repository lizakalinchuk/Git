using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Handlers
{
    public class Reversed2FilePathHandler : IFilePathHandler
    {
        private static object locker = new object();

        public void TransformFilePath(DirectoryInfo directory, FileInfo file, string initialFolder, string resultPath)
        {
            string cutFilePath = file.FullName.Substring(initialFolder.Length);
            string[] reversedFilePath = new string[] { Reverse(cutFilePath) };

            Console.WriteLine(reversedFilePath[0]);
            lock (locker)
            {
                File.AppendAllLines(resultPath, reversedFilePath);
            }
        }

        private string Reverse(string filePath)
        {
            char[] array = filePath.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
