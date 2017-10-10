using System.Web.Http;
using System.Web.Http.Results;
using TddBuddy.CleanArchitecture.Domain.Output;
using TddBuddy.CleanArchitecture.HttpResponses;

namespace TddBuddy.CleanArchitecture.Presenters
{
    public class SuccessOrErrorRestfulPresenter<TSuccess, TError> : GenericRestfulPresenter, IRespondWithSuccessOrError<TSuccess, TError>, IRespondWithNoContent
        where TSuccess : class
        where TError : class
    {
        private readonly ApiController _controller;

        public SuccessOrErrorRestfulPresenter(ApiController controller)
        {
            _controller = controller;
        }

        public void Respond(TError output)
        {
            RespondWith(new UnprocessasbleEntityResult<TError>(output, _controller));
        }

        public void Respond(TSuccess output)
        {
            RespondWith(new OkNegotiatedContentResult<TSuccess>(output, _controller));
        }

        public void Respond()
        {
            RespondWith(new OkResult(_controller));
        }
    }
}