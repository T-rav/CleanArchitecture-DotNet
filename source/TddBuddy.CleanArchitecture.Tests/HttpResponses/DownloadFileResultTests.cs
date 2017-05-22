using System;
using NSubstitute;
using NUnit.Framework;
using TddBuddy.CleanArchitecture.Domain.Output;
using TddBuddy.CleanArchitecture.HttpResponses;

namespace TddBuddy.CleanArchitecture.Tests.HttpResponses
{
    [TestFixture]
    public class DownloadFileResultTests
    {
        [Test]
        public void Ctor_WhenNullIFileOutput_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var expected = "fileOutput";
            //---------------Execute Test ----------------------
            var result = Assert.Throws<ArgumentNullException>(() => new DownloadFileResult(null));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result.ParamName);
        }

        [Test]
        public void Ctor_WhenNotNullIFileOutput_ShouldNotThrowException()
        {
            //---------------Set up test pack-------------------
            var expected = "fileOutput";
            var input = Substitute.For<IFileOutput>();
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.DoesNotThrow(() => new DownloadFileResult(input));
        }
    }
}
