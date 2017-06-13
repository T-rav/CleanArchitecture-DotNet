using System.Web.Http;
using System.Web.Http.Results;
using NSubstitute;
using NUnit.Framework;
using TddBuddy.CleanArchitecture.Domain.Messages;
using TddBuddy.CleanArchitecture.HttpResponses;
using TddBuddy.CleanArchitecture.Presenters;

namespace TddBuddy.CleanArchitecture.Tests.Presenters
{
    [TestFixture]
    public class ErrorRestfulPresenterTests
    {
        [Test]
        public void Render_GivenNoResponse_ShouldReturnOkResult()
        {
            //---------------Set up test pack-------------------
            var presenter = CreatePresenter();
            //---------------Execute Test ----------------------
            var result = presenter.Render() as OkResult;
            //---------------Test Result -----------------------
            Assert.IsNotNull(result);
        }

        [Test]
        public void Render_GivenErrorResponse_ShouldReturnUnprocessableEntityResultWithContent()
        {
            //---------------Set up test pack-------------------
            var content = new ErrorOutputMessage();
            var presenter = CreatePresenter();
            presenter.Respond(content);
            //---------------Execute Test ----------------------
            var result = presenter.Render() as UnprocessasbleEntityResult<ErrorOutputMessage>;
            //---------------Test Result -----------------------
            Assert.IsNotNull(result);
            Assert.AreEqual(content, result.Content);
        }

        private ErrorRestfulPresenter<ErrorOutputMessage> CreatePresenter()
        {
            var apiController = Substitute.For<ApiController>();
            return new ErrorRestfulPresenter<ErrorOutputMessage>(apiController);
        }
    }
}