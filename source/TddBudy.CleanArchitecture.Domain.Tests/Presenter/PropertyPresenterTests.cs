using NUnit.Framework;
using TddBuddy.CleanArchitecture.Domain.Messages;
using TddBuddy.CleanArchitecture.Domain.Presenter;

namespace TddBudy.CleanArchitecture.Domain.Tests.Presenter
{
    [TestFixture]
    public class PropertyPresenterTests
    {
        [Test]
        public void Respond_WhenSuccessObject_ShouldSetSuccessProperty()
        {
            //---------------Set up test pack-------------------
            var successObject = "all good";
            var presenter = new PropertyPresenter<string, ErrorOutputMessage>();
            //---------------Execute Test ----------------------
            presenter.Respond(successObject);
            //---------------Test Result -----------------------
            Assert.AreEqual(successObject, presenter.SuccessContent);
        }

        [Test]
        public void Respond_WhenErrorObject_ShouldSetErrorProperty()
        {
            //---------------Set up test pack-------------------
            var errorObject = new ErrorOutputMessage();
            errorObject.AddError("stuff went wrong");
            var presenter = new PropertyPresenter<string, ErrorOutputMessage>();
            //---------------Execute Test ----------------------
            presenter.Respond(errorObject);
            //---------------Test Result -----------------------
            Assert.AreEqual(errorObject, presenter.ErrorContent);
        }

        [Test]
        public void IsErrorResponse_WhenErrorObjectNotNull_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var errorObject = new ErrorOutputMessage();
            errorObject.AddError("stuff went wrong");
            var presenter = new PropertyPresenter<string, ErrorOutputMessage>();
            //---------------Execute Test ----------------------
            presenter.Respond(errorObject);
            //---------------Test Result -----------------------
            Assert.IsTrue(presenter.IsErrorResponse());
        }

        [Test]
        public void IsErrorResponse_WhenErrorObjectNull_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var successObject = "all good";
            var presenter = new PropertyPresenter<string, ErrorOutputMessage>();
            //---------------Execute Test ----------------------
            presenter.Respond(successObject);
            //---------------Test Result -----------------------
            Assert.IsFalse(presenter.IsErrorResponse());
        }
    }
}