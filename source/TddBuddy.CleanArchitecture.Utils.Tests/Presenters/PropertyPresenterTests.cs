using CleanArchitecture.Utils.Presenters;
using CleanArchitecture.Utils.TOs;
using NUnit.Framework;

namespace Tddbuddy.CleanArchitecture.Utils.Tests.Presenters
{
    [TestFixture]
    public class PropertyPresenterTests
    {
        [Test]
        public void IsErrorResponse_WhenNoErrors_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var presenter = new PropertyPresenter<object, ErrorOutputTo>();
            //---------------Execute Test ----------------------
            var result = presenter.IsErrorResponse();
            //---------------Test Result -----------------------
            Assert.False(result);
        }

        [Test]
        public void IsErrorResponse_WhenErrors_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var presenter = new PropertyPresenter<object, ErrorOutputTo>();
            presenter.Respond(new ErrorOutputTo());
            //---------------Execute Test ----------------------
            var result = presenter.IsErrorResponse();
            //---------------Test Result -----------------------
            Assert.True(result);
        }

        [Test]
        public void ErrorContent_WhenErrors_ShouldReturnErrorTo()
        {
            //---------------Set up test pack-------------------
            var errors = new ErrorOutputTo();
            var presenter = new PropertyPresenter<object, ErrorOutputTo>();
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
            var presenter = new PropertyPresenter<object, ErrorOutputTo>();
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
            var presenter = new PropertyPresenter<object, ErrorOutputTo>();
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
            var presenter = new PropertyPresenter<object, ErrorOutputTo>();
            //---------------Execute Test ----------------------
            var result = presenter.SuccessContent;
            //---------------Test Result -----------------------
            Assert.Null(result);
        }
    }
}
