using System.Web.Http;
using TddBuddy.CleanArchitecture.Utils.Output;

namespace TddBuddy.CleanArchitecture.Utils.Presenters
{
    public class SuccessOrErrorRestfulPresenter<TSuccess, TError> : GenericRestfulPresenter<TSuccess, TError>, IRespondWithSuccessOrError<TSuccess, TError>
        where TSuccess : class
        where TError : class
    {
        public SuccessOrErrorRestfulPresenter(ApiController controller) : base(controller)
        {
        }

        public void Respond(TError output)
        {
            RespondWithUnprocessableEntity(output);
        }

        public void Respond(TSuccess output)
        {
            RespondWithOk(output);
        }
    }
}