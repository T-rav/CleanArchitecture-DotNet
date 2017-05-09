using System.Web.Http;
using System.Web.Http.Results;
using CleanArchitecture.Utils.HttpResponses;
using CleanArchitecture.Utils.Presenters;
using CleanArchitecture.Utils.TOs;
using NSubstitute;
using NUnit.Framework;

namespace CleanArchitecture.Utils.Tests.Presenters
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