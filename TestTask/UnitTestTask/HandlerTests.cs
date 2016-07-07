using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask.Handlers;

namespace UnitTestTask
{
    [TestClass]
    public class HandlerTests
    {
        [TestMethod]
        public void Reversed1FilePathHandlerTest_ReverseFilePath_GetReversedFilePath()
        {
            // act
            PrivateObject obj = new PrivateObject(typeof(Reversed1FilePathHandler));
            string result = Convert.ToString(obj.Invoke("SplitAndReverseWords", "Test\\test.txt"));

            // assert
            Assert.AreEqual("test.txt\\Test", result);
        }

        [TestMethod]
        public void Reversed2FilePathHandlerTest_ReverseFilePath_GetReversedFilePath()
        {
            // act
            PrivateObject obj = new PrivateObject(typeof(Reversed2FilePathHandler));
            string result = Convert.ToString(obj.Invoke("Reverse", "Test\\test.txt"));

            // assert
            Assert.AreEqual("txt.tset\\tseT", result);
        }
    }
}
