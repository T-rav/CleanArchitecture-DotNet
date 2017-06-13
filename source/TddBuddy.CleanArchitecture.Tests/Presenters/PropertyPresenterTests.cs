using NUnit.Framework;
using TddBuddy.CleanArchitecture.Domain.Messages;
using TddBuddy.CleanArchitecture.Domain.Presenter;
using TddBuddy.CleanArchitecture.Presenters;

namespace TddBuddy.CleanArchitecture.Tests.Presenters
{
    [TestFixture]
    public class PropertyPresenterTests
    {
        [Test]
        public void IsErrorResponse_WhenNoErrors_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var presenter = new PropertyPresenter<object, ErrorOutputMessage>();
            //---------------Execute Test ----------------------
            var result = presenter.IsErrorResponse();
            //---------------Test Result -----------------------
            Assert.False(result);
        }

        [Test]
        public void IsErrorResponse_WhenErrors_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var presenter = new PropertyPresenter<object, ErrorOutputMessage>();
            presenter.Respond(new ErrorOutputMessage());
            //---------------Execute Test ----------------------
            var result = presenter.IsErrorResponse();
            //---------------Test Result -----------------------
            Assert.True(result);
        }

        [Test]
        public void ErrorContent_WhenErrors_ShouldReturnErrorTo()
        {
            //---------------Set up test pack-------------------
            var errors = new ErrorOutputMessage();
            var presenter = new PropertyPresenter<object, ErrorOutputMessage>();
            presenter.Respond(errors);
            //---------------Execute Test ----------------------
            var result = presenter.ErrorContent;
            //---------------Test Result -----------------------
            Assert.AreEqual(errors, result);
        }

        [Test]
        public void ErrorContent_WhenNoErrors_ShouldReturnNull()
        {
            //---------------Set up test pack-------------------
            var presenter = new PropertyPresenter<object, ErrorOutputMessage>();
            //---------------Execute Test ----------------------
            var result = presenter.ErrorContent;
            //---------------Test Result -----------------------
            Assert.Null(result);
        }

        [Test]
        public void SuccessContent_WhenSet_ShouldReturnObject()
        {
            //---------------Set up test pack-------------------
            var respondWith = new object();
            var presenter = new PropertyPresenter<object, ErrorOutputMessage>();
            presenter.Respond(respondWith);
            //---------------Execute Test ----------------------
            var result = presenter.SuccessContent;
            //---------------Test Result -----------------------
            Assert.AreEqual(respondWith, result);
        }

        [Test]
        public void SuccessContent_WhenNotSet_ShouldReturnNull()
        {
            //---------------Set up test pack-------------------
            var presenter = new PropertyPresenter<object, ErrorOutputMessage>();
            //---------------Execute Test ----------------------
            var result = presenter.SuccessContent;
            //---------------Test Result -----------------------
            Assert.Null(result);
        }
    }
}
