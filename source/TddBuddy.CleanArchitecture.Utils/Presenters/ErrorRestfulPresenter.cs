using System.Web.Http;
using TddBuddy.CleanArchitecture.Utils.Output;

namespace TddBuddy.CleanArchitecture.Utils.Presenters
{
    public class ErrorRestfulPresenter<TError> : GenericRestfulPresenter<object, TError>, IRespondWith<TError>
         where TError : class
    {
        public ErrorRestfulPresenter(ApiController controller) : base(controller)
        {
            DefaultResponse(presenter => presenter.RespondWithOk());
        }

        public void Respond(TError output)
        {
            RespondWithUnprocessableEntity(output);
        }
    }
}