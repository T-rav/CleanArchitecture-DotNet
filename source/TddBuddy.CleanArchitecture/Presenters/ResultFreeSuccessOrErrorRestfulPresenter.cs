using System.Web.Http;
using System.Web.Http.Results;
using TddBuddy.CleanArchitecture.Domain.Output;
using TddBuddy.CleanArchitecture.HttpResponses;

namespace TddBuddy.CleanArchitecture.Presenters
{
    public class ResultFreeSuccessOrErrorRestfulPresenter<TError> : GenericRestfulPresenter, IRespondWithNoResultSuccessOrError<TError>
    {
        private readonly ApiController _controller;

        public ResultFreeSuccessOrErrorRestfulPresenter(ApiController controller)
        {
            _controller = controller;
        }

        public void Respond(TError output)
        {
            RespondWith(new UnprocessasbleEntityResult<TError>(output, _controller));
        }

        public void Respond()
        {
            RespondWith(new OkResult(_controller));
        }

    }
}