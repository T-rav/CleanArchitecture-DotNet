using System.Web.Http;
using System.Web.Http.Results;
using NSubstitute;
using NUnit.Framework;
using TddBuddy.CleanArchitecture.Domain.TOs;
using TddBuddy.CleanArchitecture.HttpResponses;
using TddBuddy.CleanArchitecture.Presenters;

namespace TddBuddy.CleanArchitecture.Tests.Presenters
{
    [TestFixture]
    public class SuccessOrErrorRestfulPresenterTests
    {
        [Test]
        public void Render_GivenSuccessfullResponse_ShouldReturnOkResultWithContent()
        {
            //---------------Set up test pack-------------------
            var content = new object();
            var presenter = CreatePresenter();
            presenter.Respond(content);
            //---------------Execute Test ----------------------
            var result = presenter.Render() as OkNegotiatedContentResult<object>;
            //---------------Test Result -----------------------
            Assert.IsNotNull(result);
            Assert.AreEqual(content, result.Content);
        }

        [Test]
        public void Render_GivenErrorResponse_ShouldReturnUnprocessableEntityResultWithContent()
        {
            //---------------Set up test pack-------------------
            var content = new ErrorOutputTo();
            content.AddError("Error message");

            var presenter = CreatePresenter();
            presenter.Respond(content);
            //---------------Execute Test ----------------------
            var result = presenter.Render() as UnprocessasbleEntityResult<ErrorOutputTo>;
            //---------------Test Result -----------------------
            Assert.IsNotNull(result);
            Assert.AreEqual(content, result.Content);
        }

        private SuccessOrErrorRestfulPresenter<object, ErrorOutputTo> CreatePresenter()
        {
            var apiController = Substitute.For<ApiController>();
            return new SuccessOrErrorRestfulPresenter<object, ErrorOutputTo>(apiController);
        }
    }
}