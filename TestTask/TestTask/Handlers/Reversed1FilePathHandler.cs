using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Handlers
{
    public class Reversed1FilePathHandler : IFilePathHandler
    {
        private static object locker = new object();

        public void TransformFilePath(DirectoryInfo directory, FileInfo file, string initialFolder, string resultPath)
        {
            string cutFilePath = file.FullName.Substring(initialFolder.Length);
            string[] reversedFilePath = new string[] { SplitAndReverseWords(cutFilePath) };

            Console.WriteLine(reversedFilePath[0]);
            lock (locker)
            {
                File.AppendAllLines(resultPath, reversedFilePath);
            }
        }

        private string SplitAndReverseWords(string filePath)
        {
            var reversed = new StringBuilder();
            string[] splittedArray = filePath.Split('\\');
            for (int i = splittedArray.Length - 1; i >= 0; i--)
            {
                reversed.Append(splittedArray[i]);
                if (i != 0)
                {
                    reversed.Append("\\");
                }
            }
            return reversed.ToString();
        }
    }
}
