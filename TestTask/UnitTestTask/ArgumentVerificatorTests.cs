using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask;
using System.IO;

namespace UnitTestTask
{
    [TestClass]
    public class ArgumentVerificatorTests
    {
        [TestMethod]
        public void VerifyArgsCountATest_EnterCorrectArguments_ReturnTrue()
        {
            // arrange
            string dir = Directory.GetCurrentDirectory();
            string[] args = new string[] { dir, "all" };
            //act
            bool result = ArgumentVerificator.VerifyArgsCount(args);
            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VerifyArgsCountTest_DoNotEnterArgument_ReturnFalse()
        {
            // arrange
            string[] args = new string[] { };
            //act
            bool result = ArgumentVerificator.VerifyArgsCount(args);
            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void VerifyExistanceInitDirTest_EnterCorrectFirstArgument_ReturnTrue()
        {
            // arrange
            string dir = Directory.GetCurrentDirectory();
            string[] args = new string[] { dir };
            //act
            bool result = ArgumentVerificator.VerifyExistanceInitDir(args);
            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VerifyExistanceInitDirTest_EnterIncorrectFirstArgument_ReturnFalse()
        {
            // arrange
            string dir = Directory.GetCurrentDirectory();
            string incorrectDir = Path.Combine(dir, "IncorrectPath");
            string[] args = new string[] { incorrectDir };
            //act
            bool result = ArgumentVerificator.VerifyExistanceInitDir(args);
            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void VerifyExistenceResultFileTest_EnterIncorrectResultFilePathArguments_ReturnFalse()
        {
            // arrange
            string dir = Directory.GetCurrentDirectory();
            string path = "C:/resultTest.txt";
            string[] args = new string[] { dir, "all", path };
            //act
            bool result = ArgumentVerificator.VerifyExistenceResultFile(args);
            // assert
            Assert.IsFalse(result);
        }
    }
}
