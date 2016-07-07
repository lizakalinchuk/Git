using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask.DI;
using TestTask.Handlers;
using System.IO;

namespace UnitTestTask
{
    [TestClass]
    public class DependencyTests
    {
        [TestMethod]
        public void ResolveFilePathHandlerTests_EnterActionName_GetCorrectHandler()
        {
            // act
            var cррHandler = Dependency.ResolveFilePathHandler("cpp");
            var allHandler = Dependency.ResolveFilePathHandler("all");
            var reversed1Handler = Dependency.ResolveFilePathHandler("reversed1");
            var reverse21Handler = Dependency.ResolveFilePathHandler("reversed2");
            // assert
            Assert.IsInstanceOfType(cррHandler, typeof(CррFilePathHandler));
            Assert.IsInstanceOfType(allHandler, typeof(AllFilePathHandler));
            Assert.IsInstanceOfType(reversed1Handler, typeof(Reversed1FilePathHandler));
            Assert.IsInstanceOfType(reverse21Handler, typeof(Reversed2FilePathHandler)); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ResolveFilePathHandlerTests_EnterIncorrectActionName_GetException()
        {
            // act
            var cррHandler = Dependency.ResolveFilePathHandler("incorrect");
        }

        [TestMethod]
        public void ResolveDirectoryHandlerTests_EnterParameters_GetCorrectHandler()
        {
            // arrange
            var dir = Directory.GetCurrentDirectory();
            // act
            var cррHandler = Dependency.ResolveDirectoryHandler(new CррFilePathHandler(), dir);
            // assert
            Assert.IsInstanceOfType(cррHandler, typeof(DirectoryHandler));
        }
    }
}
