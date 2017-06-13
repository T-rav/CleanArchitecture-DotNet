using NUnit.Framework;
using TddBuddy.CleanArchitecture.Domain.Messages;

namespace TddBudy.CleanArchitecture.Domain.Tests.TOs
{
    [TestFixture]
    public class ErrorOutputToTests
    {
        [Test]
        public void FetchErrors_WhenConstructed_ShouldReturnList()
        {
            //---------------Set up test pack-------------------
            //---------------Execute Test ----------------------
            var result = new ErrorOutputMessage();
            //---------------Test Result -----------------------
            Assert.NotNull(result.Errors);
        }

        [Test]
        public void HasErrors_WhenNoErrors_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var errorOutputTo = new ErrorOutputMessage();
            //---------------Execute Test ----------------------
            var result = errorOutputTo.HasErrors;
            //---------------Test Result -----------------------
            Assert.False(result);
        }

        [Test]
        public void HasErrors_WhenErrors_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var errorOutputTo = new ErrorOutputMessage();
            errorOutputTo.AddError("test error");
            //---------------Execute Test ----------------------
            var result = errorOutputTo.HasErrors;
            //---------------Test Result -----------------------
            Assert.True(result);
        }
    }
}
